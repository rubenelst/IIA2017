/* 
Initiation file for tags
Use this script to create the desired tags.
*/
EXEC ConfigureTag @TagId = 1, @TagName = 'PV', @TagDescription = 'Temperature measured on the outlet of the Air Heater')
EXEC ConfigureTag @TagId = 2, @TagName = 'SP', @TagDescription = 'Set point for the desired Temperature')
EXEC ConfigureTag @TagId = 3, @TagName = 'u', @TagDescription = 'Control value sent to the Air Heater')
EXEC ConfigureTag @TagId = 4, @TagName = 'Ti', @TagDescription = 'Controller Integral parameter')
EXEC ConfigureTag @TagId = 5, @TagName = 'Kp', @TagDescription = 'Controller Proportional parameter')
EXEC ConfigureTag @TagId = 6, @TagName = 'd', @TagDescription = 'Controller Derivative parameter')
EXEC ConfigureTag @TagId = 7, @TagName = 'z', @TagDescription = 'Controller internal variable to determine integral time')