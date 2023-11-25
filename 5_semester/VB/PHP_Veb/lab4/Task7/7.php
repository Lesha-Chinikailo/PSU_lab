<?php
session_start();
if (!isset($_SESSION["time"])) {
    $_SESSION["time"] = time();
}
echo "Вы зашли на сайт " . (time() - $_SESSION["time"]) . " секунд назад";
