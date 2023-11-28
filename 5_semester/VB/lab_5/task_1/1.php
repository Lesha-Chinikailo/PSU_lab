<?php
function myException($exception)
{
    echo "<br>";
    echo "Error message: ".$exception->getMessage()."<br>";
    echo "File: ".$exception->getFile()." on line ".$exception->getLine()."<br>";
    $errorTrace = debug_backtrace();
    echo "Trace: <br>";
    foreach ($errorTrace as $index => $call) {
        highlight_string("Call " . ($index + 1) . ": " . $call['function'] . " in " . $call['file'] . " on line " . $call['line']);
        echo "<br>";
    }
}


try {
    $fd = fopen("t.txt", 'r');
    if(!$fg)
        throw new Exception('Не удалось открыть файл ' . $fd);
} 
catch (Exception $e) {
    myException($e);
}
