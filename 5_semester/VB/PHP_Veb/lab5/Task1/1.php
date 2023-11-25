<?php
function myExceptionHandler($exception)
{
    $errorMessage = $exception->getMessage();
    $errorFile = $exception->getFile();
    $errorLine = $exception->getLine();
    $errorTrace = debug_backtrace();
    echo "<br>";
    echo "Error message: " . $errorMessage . "<br>";
    echo "File: " . $errorFile . " on line " . $errorLine . "<br>";
    echo "Trace: <br>";
    foreach ($errorTrace as $index => $call) {
        highlight_string("Call " . ($index + 1) . ": " . $call['function'] . " in " . $call['file'] . " on line " . $call['line']);
        echo "<br>";
    }
}

function myShutdownHandler()
{
    $error = error_get_last();
    if ($error !== null) {
        $errorMessage = $error['message'];
        $errorFile = $error['file'];
        $errorLine = $error['line'];
        echo "<br>";
        echo "File: " . $errorFile . " on line " . $errorLine . "<br>";
        echo "Error message: " . $errorMessage . "<br>";
    }
}

set_exception_handler('myExceptionHandler');
register_shutdown_function('myShutdownHandler');

try {
    $file = 'xxx.xxx';
    $handle = fopen($file, 'r');
    if (!$handle) {
        throw new Exception('Не удалось открыть файл ' . $file);
    }
} catch (Exception $e) {
    myExceptionHandler($e);
}
