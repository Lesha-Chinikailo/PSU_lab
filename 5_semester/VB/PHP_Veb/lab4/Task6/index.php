<form method="POST">
	<input type="text" name="country">
	<input type="submit">
</form>

<?php
if (isset($_POST['country'])) {
	session_start();
	$_SESSION['country'] = $_POST['country'];
}
?>