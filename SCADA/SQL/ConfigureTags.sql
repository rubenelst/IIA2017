/* 
Initiation file for tags
Use this script to create the desired tags.
*/
EXEC ConfigureTag @TagId = 1, @TagName = 'PV', @TagDescription = 'Tank Level [cm]';
EXEC ConfigureTag @TagId = 2, @TagName = 'SP', @TagDescription = 'Set point for the Tank Level [cm]';
EXEC ConfigureTag @TagId = 3, @TagName = 'u', @TagDescription = 'Control value sent to the pump [V]';