<?php
namespace lab5_3_3;
function getFolderSize($dir)
{
    $totalSize = 0;
    $files = glob("$dir/*");
    foreach ($files as $file) {
        $totalSize += is_file($file) ? filesize($file) : getFolderSize($file);
    }
    return $totalSize;
}
 echo getFolderSize(getcwd()."/test");




#$fg = opendir(getcwd());
#$summ = 0;
#while (($file = readdir($fg)) !== false) {
#    $summ += is_file($file) ? filesize($file) : folderSize($file);
#}