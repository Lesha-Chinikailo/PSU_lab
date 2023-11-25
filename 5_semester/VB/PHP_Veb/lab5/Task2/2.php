<form method="POST">
<input type="text" name="str">
<input type="submit">
</form>

<?php
if (isset($_POST['str'])) {
$strNumber = intval($_POST['str']); 
echo "Будет удалена строка с номером " . $strNumber . "<br>";

$sourceFile = fopen('xxx.txt', 'r');
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
unlink('xxx.txt');
rename('newFile.txt', 'xxx.txt');

$xxx = fopen('xxx.txt', 'r');
while (!feof($xxx)) {
echo fgets($xxx);
}
fclose($xxx);
} else {
echo "Номер удаляемой строки не передан";
}