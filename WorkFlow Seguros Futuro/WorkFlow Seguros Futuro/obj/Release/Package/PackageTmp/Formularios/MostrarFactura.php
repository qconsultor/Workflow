
<?php
$file ='file://172.16.2.219/sf_par/adquisiciones/WORKFLOW/pruebas_scaner/'.$_GET["EMISION_9365.pdf"];
 
$filename = $_GET["EMISION_9365.pdf"];
 
header('Content-type: application/pdf');// esta linea fue mi dolor de cabeza
header('Content-Disposition: inline; filename="' . $filename . '"');
header('Content-Transfer-Encoding: binary');
header('Content-Length: ' . filesize($file));
header('Accept-Ranges: bytes');
 
@readfile($file);
?>