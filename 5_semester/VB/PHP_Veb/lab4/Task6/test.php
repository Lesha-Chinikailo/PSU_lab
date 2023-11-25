<?php
session_start();
if (isset($_SESSION['country'])) {
	echo $_SESSION['country'];
}
