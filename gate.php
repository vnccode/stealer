<?php
error_reporting(0);

$ip = $_SERVER['REMOTE_ADDR']; 

file_put_contents('accesslog.txt', $ip.PHP_EOL , FILE_APPEND | LOCK_EX);

$id = rawurlencode($_GET['id'] ?? $POST['id'] ?? '');
if (is_uploaded_file(isset($_FILES['file']['tmp_name'])?($_FILES['file']['tmp_name']):0)) 
{
$uploadfile = $uploaddir.basename($_FILES['file']['name']).".x";
$zipname = basename($_FILES['file']['name']);
if (move_uploaded_file($_FILES['file']['tmp_name'], $uploadfile)) 
{
$arr = explode(".", $uploadfile);
$id = $arr[0];
$ip = gethostbyaddr($ip); 
$zip = new ZipArchive(); 
$zip->open("loghfv123.zip", ZIPARCHIVE::CREATE); 
$zip->addFile($uploadfile,$ip."-".$id."/".$zipname); 
$zip->close();	
unlink($uploadfile);
}
}
?>
