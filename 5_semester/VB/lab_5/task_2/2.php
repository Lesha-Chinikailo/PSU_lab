<form method="POST">
    <input type="text" name="str">
    <input type="submit">
</form>

<?php
if (isset($_POST['str'])) {
    $strNumber = intval($_POST['str']); 
    echo "Будет удалена строка с номером " . $strNumber . "<br>";

    $sourceFile = fopen('file.txt', 'r');
    $newFile = fopen('newFile.txt', 'w');

    $currentStr = 0;
    while (!feof($sourceFile)) {
        $currentStr++;
        $str = fgets($sourceFile);
        if ($currentStr !== $strNumber) {
            fwrite($newFile, $str); 
        }
    }
    fclose($sourceFile);
    fclose($newFile);
    unlink('file.txt');
    rename('newFile.txt', 'file.txt');

    $file = fopen('file.txt', 'r');
    while (!feof($file)) {
        echo fgets($file)."<br>";
    }
    fclose($file);
    } else {
    echo "Номер удаляемой строки не передан";
}