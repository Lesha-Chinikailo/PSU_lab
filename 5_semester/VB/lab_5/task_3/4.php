<?php
namespace lab5_3_4;
function getFolderSize($dir)
{
    $totalSize = 0;
    $files = glob("$dir/*");
    foreach ($files as $file) {
        $totalSize += is_file($file) ? filesize($file) : getFolderSize($file);
    }
    return $totalSize;
}

$dir = glob(getcwd() ."\\test\*");
foreach ($dir as $d) {
    if(is_dir($d)) {
        echo "name dir: ".$d."      size: ".getFolderSize($d)."<br>";
    }
}