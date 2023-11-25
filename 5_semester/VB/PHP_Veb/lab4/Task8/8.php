<form method="POST">
	<input type="text" name="email">
	<input type="submit">
</form>

<?php
if (isset($_POST['email'])) {
	session_start();
	$_SESSION['email'] = $_POST['email'];
}
?>