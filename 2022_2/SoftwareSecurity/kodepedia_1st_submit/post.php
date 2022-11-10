<?php
 session_start();
 $color = $_POST['co'];
 $sport = $_POST['sp'];
?>

<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>Post Word</title>
  <link href="post.css" rel="stylesheet">
</head>

<body>
  <form method="post" action="word_adding.php">
  <p><label> Word : <input type="text" name="co"></label></p>
  <p><label> Description : </p>
  <input type="text" name="sp"></label>
  <p><input type="submit" value="Submit"></p>
  </form>
<button class = "return" onclick="location.href='main.php'">Return main</button>
 </body>
</html>
