<?php
$ProjectPhpServer = 'production';
if ($ProjectPhpServer === 'development' || $ProjectPhpServer === 'production') {
    $defaultPath = 'config/default';
    foreach (glob($defaultPath . '/*.php') as $file) {
        include_once $file;
    }

    $config = [
        'db' => $db ?? null,
        'debug' => $debug ?? null,
        'language' => $language ?? null,
        'template' => $template ?? null,
    ];

    $serverPath = 'config/' . $ProjectPhpServer;
    foreach (glob($serverPath . '/*.php') as $file) {
        include_once $file;
    }

    if (isset($db)) {
        $config['db'] = $db;
    }

    if (isset($language)) {
        $config['language'] = $language;
    }
} else {
    $defaultPath = 'config/default';
    foreach (glob($defaultPath . '/*.php') as $file) {
        include_once $file;
    }

    $config = [
        'db' => $db ?? null,
        'debug' => $debug ?? null,
        'language' => $language ?? null,
        'template' => $template ?? null,
    ];
}

print_r($config);
