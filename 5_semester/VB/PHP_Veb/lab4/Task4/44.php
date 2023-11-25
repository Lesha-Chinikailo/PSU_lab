<?php
session_start();
if (isset($_SESSION["xxx"])) {
    echo $_SESSION["xxx"];
}
?>