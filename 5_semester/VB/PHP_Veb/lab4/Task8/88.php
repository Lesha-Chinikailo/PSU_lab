<?php
session_start();
if (isset($_SESSION['email']))
	$email = $_SESSION['email'];
else
	$email = '';
?>

<form method="POST">
	<h3>Логин:</h3>
	<input type="text"><br>
	<h3>Пароль:</h3>
	<input type="text"><br>
	<h3>Email:</h3>
	<input type="text" value="<?php echo $email ?>"><br>
	<input type="submit">
</form>