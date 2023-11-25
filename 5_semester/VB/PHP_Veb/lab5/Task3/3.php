<?php
function getFolderSize()
{
    $totalSize = 0;
    $files = glob('test/*');
    foreach ($files as $file) {
        $totalSize += is_file($file) ? filesize($file) : getFolderSize($file);
    }
    return $totalSize;
}

echo getFolderSize();