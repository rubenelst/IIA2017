CREATE PROCEDURE ConfigureTag @TagId int, @TagName varchar(18), @TagDescription varchar(50)
AS
BEGIN
	INSERT INTO TAG (TagId, TagValue, TagName, TagDescription) VALUES (@TagId, 0.0, @TagName, @TagDescription)
END
GO


CREATE PROCEDURE LogData @TagName varchar(18), @TagValue decimal(3,1), @TagUnit varchar(18)
AS
BEGIN
	UPDATE TAG SET TagValue = @TagValue, TagUnit = @TagUnit WHERE TagName = @TagName
END
GO

CREATE PROCEDURE AckAlarm @AlarmId int
AS
UPDATE ALARM SET AckStatus = 1 WHERE AlarmId = @AlarmId
GO

CREATE TRIGGER LogHistory
ON [TAG]
FOR
INSERT, UPDATE
AS
DECLARE @TagValue decimal(3,1),
		@TagUnit varchar(18),
		@TagId int

SELECT @TagValue = TagValue FROM INSERTED
SELECT @TagId = TagId FROM INSERTED
SELECT @TagUnit = TagUnit FROM INSERTED

INSERT INTO HISTORY (TagId, Value, Unit) VALUES (@TagId, @TagValue, @TagUnit)
GO

CREATE TRIGGER DetermineQuality
ON [HISTORY]
FOR
INSERT, UPDATE
AS
DECLARE @Value decimal(3,1),
		@Quality varchar(18),
		@HistoryId int

SELECT @Value = [Value] FROM INSERTED
SELECT @HistoryId = HistoryId FROM INSERTED

IF (@Value BETWEEN -50 AND 70)
BEGIN
	SET @Quality = 'GOOD'
END
ELSE
BEGIN
	SET @Quality = 'BAD'
END
UPDATE HISTORY SET Quality = @Quality WHERE HistoryId = @HistoryId 
GO

CREATE TRIGGER HighAlarm
ON [HISTORY]
FOR
INSERT
AS
BEGIN
	DECLARE @Value decimal(3,1),
			@PreviousValue decimal(3,1),
			@HistoryId int,
			@TagId int

	SELECT @Value = [Value] FROM INSERTED
	SELECT @HistoryId = HistoryId FROM INSERTED
	SELECT @PreviousValue = [Value] FROM [HISTORY] WHERE HistoryId = (@HistoryId-7)
	SELECT @TagId = TagId FROM INSERTED

	IF (@TagId = 1 AND @Value >= 28 AND @PreviousValue < 28)
	BEGIN
		INSERT INTO ALARM (TagId, AlarmName, AlarmDescription, Severity) VALUES (@TagId, 'High PV','WARNING: High Process Value detected', 1)
	END
	IF (@TagId = 1 AND @Value >= 32 AND @PreviousValue < 32)
	BEGIN
		INSERT INTO ALARM (TagId, AlarmName, AlarmDescription, Severity) VALUES (@TagId, 'Very High PV','ALARM: Very High Process Value detected!', 2)
	END
	IF (@TagId = 1 AND @Value >= 36 AND @PreviousValue < 36)
	BEGIN
		INSERT INTO ALARM (TagId, AlarmName, AlarmDescription, Severity) VALUES (@TagId, 'Critical PV','ALARM: Critical Process Value detected!', 3)
	END
END
GO

CREATE TRIGGER BadQuality
ON [HISTORY]
FOR
UPDATE
AS
DECLARE @Quality varchar(18),
		@HistoryId int,
		@TagId int

SELECT @Quality = Quality FROM INSERTED
SELECT @TagId = TagId FROM INSERTED

IF (@Quality = 'Bad')
BEGIN
	INSERT INTO ALARM (TagId, AlarmName, AlarmDescription, Severity) VALUES (@TagId, 'Bad Quality','WARNING: Bad data quality detected', 1)
END
GO