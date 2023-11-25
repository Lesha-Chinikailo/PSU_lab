<?php
foreach (glob('*.php') as $file) {
    include_once $file;
}
?>