<?php

$a = 0;
$b = 0;
$c = 1;
$s = 0;

do{
	if($c%2==0)
		$s+=$c;
		
	$a=$b;
	$b=$c;
	$c=$a+$b;
}while($c<4000000);

echo $s;


?>