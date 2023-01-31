
CREATE TABLE [ALARM]
( 
	[AlarmId]            integer  IDENTITY(1,1)  NOT NULL ,
	[TagId]              integer  NULL ,
	[AlarmName]          varchar(18)  NULL ,
	[AlarmDescription]   varchar(50)  NULL ,
	[Severity]           integer  NULL ,
	[AckStatus]          bit DEFAULT(0) NULL 
)
go

CREATE TABLE [HISTORY]
( 
	[HistoryId]          integer  IDENTITY(1,1)  NOT NULL ,
	[TagId]              integer  NULL ,
	[Value]              decimal(3,1)  NULL ,
	[Quality]            varchar(18)  NULL ,
	[TimeStamp]          datetime  DEFAULT(getdate())  NULL 
)
go

CREATE TABLE [TAG]
( 
	[TagName]            varchar(18)  NULL ,
	[TagId]              integer  NOT NULL ,
	[TagValue]           decimal(3,1)  NULL ,
	[TagDescription]     varchar(50)  NULL 
)
go

ALTER TABLE [ALARM]
	ADD CONSTRAINT [XPKSENSOR] PRIMARY KEY  CLUSTERED ([AlarmId] ASC)
go

ALTER TABLE [HISTORY]
	ADD CONSTRAINT [XPKDATA] PRIMARY KEY  CLUSTERED ([HistoryId] ASC)
go

ALTER TABLE [TAG]
	ADD CONSTRAINT [XPKTEMPERATURE] PRIMARY KEY  CLUSTERED ([TagId] ASC)
go


ALTER TABLE [ALARM]
	ADD CONSTRAINT [R_4] FOREIGN KEY ([TagId]) REFERENCES [TAG]([TagId])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [HISTORY]
	ADD CONSTRAINT [R_3] FOREIGN KEY ([TagId]) REFERENCES [TAG]([TagId])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


CREATE TRIGGER tD_ALARM ON ALARM FOR DELETE AS
/* erwin Builtin Trigger */
/* DELETE trigger on ALARM */
BEGIN
  DECLARE  @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)
    /* erwin Builtin Trigger */
    /* TAG  ALARM on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="000125a0", PARENT_OWNER="", PARENT_TABLE="TAG"
    CHILD_OWNER="", CHILD_TABLE="ALARM"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_4", FK_COLUMNS="TagId" */
    IF EXISTS (SELECT * FROM deleted,TAG
      WHERE
        /* %JoinFKPK(deleted,TAG," = "," AND") */
        deleted.TagId = TAG.TagId AND
        NOT EXISTS (
          SELECT * FROM ALARM
          WHERE
            /* %JoinFKPK(ALARM,TAG," = "," AND") */
            ALARM.TagId = TAG.TagId
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last ALARM because TAG exists.'
      GOTO error
    END


    /* erwin Builtin Trigger */
    RETURN
error:
   RAISERROR (@errmsg, -- Message text.
              @severity, -- Severity (0~25).
              @state) -- State (0~255).
    rollback transaction
END

go


CREATE TRIGGER tU_ALARM ON ALARM FOR UPDATE AS
/* erwin Builtin Trigger */
/* UPDATE trigger on ALARM */
BEGIN
  DECLARE  @numrows int,
           @nullcnt int,
           @validcnt int,
           @insAlarmId integer,
           @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)

  SELECT @numrows = @@rowcount
  /* erwin Builtin Trigger */
  /* TAG  ALARM on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00017358", PARENT_OWNER="", PARENT_TABLE="TAG"
    CHILD_OWNER="", CHILD_TABLE="ALARM"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_4", FK_COLUMNS="TagId" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(TagId)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,TAG
        WHERE
          /* %JoinFKPK(inserted,TAG) */
          inserted.TagId = TAG.TagId
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    select @nullcnt = count(*) from inserted where
      inserted.TagId IS NULL
    IF @validcnt + @nullcnt != @numrows
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update ALARM because TAG does not exist.'
      GOTO error
    END
  END


  /* erwin Builtin Trigger */
  RETURN
error:
   RAISERROR (@errmsg, -- Message text.
              @severity, -- Severity (0~25).
              @state) -- State (0~255).
    rollback transaction
END

go




CREATE TRIGGER tD_HISTORY ON HISTORY FOR DELETE AS
/* erwin Builtin Trigger */
/* DELETE trigger on HISTORY */
BEGIN
  DECLARE  @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)
    /* erwin Builtin Trigger */
    /* TAG  HISTORY on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00012d81", PARENT_OWNER="", PARENT_TABLE="TAG"
    CHILD_OWNER="", CHILD_TABLE="HISTORY"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_3", FK_COLUMNS="TagId" */
    IF EXISTS (SELECT * FROM deleted,TAG
      WHERE
        /* %JoinFKPK(deleted,TAG," = "," AND") */
        deleted.TagId = TAG.TagId AND
        NOT EXISTS (
          SELECT * FROM HISTORY
          WHERE
            /* %JoinFKPK(HISTORY,TAG," = "," AND") */
            HISTORY.TagId = TAG.TagId
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last HISTORY because TAG exists.'
      GOTO error
    END


    /* erwin Builtin Trigger */
    RETURN
error:
   RAISERROR (@errmsg, -- Message text.
              @severity, -- Severity (0~25).
              @state) -- State (0~255).
    rollback transaction
END

go


CREATE TRIGGER tU_HISTORY ON HISTORY FOR UPDATE AS
/* erwin Builtin Trigger */
/* UPDATE trigger on HISTORY */
BEGIN
  DECLARE  @numrows int,
           @nullcnt int,
           @validcnt int,
           @insHistoryId integer,
           @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)

  SELECT @numrows = @@rowcount
  /* erwin Builtin Trigger */
  /* TAG  HISTORY on child update no action */
  /* ERWIN_RELATION:CHECKSUM="000174c6", PARENT_OWNER="", PARENT_TABLE="TAG"
    CHILD_OWNER="", CHILD_TABLE="HISTORY"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_3", FK_COLUMNS="TagId" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(TagId)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,TAG
        WHERE
          /* %JoinFKPK(inserted,TAG) */
          inserted.TagId = TAG.TagId
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    select @nullcnt = count(*) from inserted where
      inserted.TagId IS NULL
    IF @validcnt + @nullcnt != @numrows
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update HISTORY because TAG does not exist.'
      GOTO error
    END
  END


  /* erwin Builtin Trigger */
  RETURN
error:
   RAISERROR (@errmsg, -- Message text.
              @severity, -- Severity (0~25).
              @state) -- State (0~255).
    rollback transaction
END

go




CREATE TRIGGER tD_TAG ON TAG FOR DELETE AS
/* erwin Builtin Trigger */
/* DELETE trigger on TAG */
BEGIN
  DECLARE  @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)
    /* erwin Builtin Trigger */
    /* TAG  ALARM on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="0001cfd9", PARENT_OWNER="", PARENT_TABLE="TAG"
    CHILD_OWNER="", CHILD_TABLE="ALARM"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_4", FK_COLUMNS="TagId" */
    IF EXISTS (
      SELECT * FROM deleted,ALARM
      WHERE
        /*  %JoinFKPK(ALARM,deleted," = "," AND") */
        ALARM.TagId = deleted.TagId
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete TAG because ALARM exists.'
      GOTO error
    END

    /* erwin Builtin Trigger */
    /* TAG  HISTORY on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="TAG"
    CHILD_OWNER="", CHILD_TABLE="HISTORY"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_3", FK_COLUMNS="TagId" */
    IF EXISTS (
      SELECT * FROM deleted,HISTORY
      WHERE
        /*  %JoinFKPK(HISTORY,deleted," = "," AND") */
        HISTORY.TagId = deleted.TagId
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete TAG because HISTORY exists.'
      GOTO error
    END


    /* erwin Builtin Trigger */
    RETURN
error:
   RAISERROR (@errmsg, -- Message text.
              @severity, -- Severity (0~25).
              @state) -- State (0~255).
    rollback transaction
END

go


CREATE TRIGGER tU_TAG ON TAG FOR UPDATE AS
/* erwin Builtin Trigger */
/* UPDATE trigger on TAG */
BEGIN
  DECLARE  @numrows int,
           @nullcnt int,
           @validcnt int,
           @insTagId integer,
           @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)

  SELECT @numrows = @@rowcount
  /* erwin Builtin Trigger */
  /* TAG  ALARM on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="0001fdf2", PARENT_OWNER="", PARENT_TABLE="TAG"
    CHILD_OWNER="", CHILD_TABLE="ALARM"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_4", FK_COLUMNS="TagId" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(TagId)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,ALARM
      WHERE
        /*  %JoinFKPK(ALARM,deleted," = "," AND") */
        ALARM.TagId = deleted.TagId
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update TAG because ALARM exists.'
      GOTO error
    END
  END

  /* erwin Builtin Trigger */
  /* TAG  HISTORY on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="TAG"
    CHILD_OWNER="", CHILD_TABLE="HISTORY"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_3", FK_COLUMNS="TagId" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(TagId)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,HISTORY
      WHERE
        /*  %JoinFKPK(HISTORY,deleted," = "," AND") */
        HISTORY.TagId = deleted.TagId
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update TAG because HISTORY exists.'
      GOTO error
    END
  END


  /* erwin Builtin Trigger */
  RETURN
error:
   RAISERROR (@errmsg, -- Message text.
              @severity, -- Severity (0~25).
              @state) -- State (0~255).
    rollback transaction
END

go
