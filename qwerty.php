<html>
<body>

<?php
$meters=$dis[height];
$inches_per_meter = 39.3700787;
$inches_total = round($meters * $inches_per_meter); 
$feet = $inches_total / 12 ; 
$inches = $inches_total % 12; 
echo "(". round($feet,1) .")";
?>
</body>
</html>