<?php
session_start();
?>

<!DOCTYPE HTML>
<html lang="en">
<html>
<head>
  <meta charset="UTF-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>KodePedia</title>
  <link href="mainpage.css" rel="stylesheet">
</head>
<body>
  <div>
  <?php
  if($_SESSION["login"] != 1){
     ?>
            <button class = "login" onclick="location.href='login.php'">login</button> &nbsp; &nbsp; </br>
<?php }
  else {
    ?>
             <button class = "wordadd" onclick="location.href='post.php'">post</button><p></p>
<button class = "logout" onclick="location.href='logout.php'">logout</button>
<?php } ?>
            <div>
                <img src="logo.png"  class= "logo " alt="" height="400">
            </div>
            <h1 class="headerPedia">KODEPEDIA</h1>
            <form method="post" action="word_search.php">
            <input type="text" name="searching" placeholder="What do you want to know?">
            <p><input type="submit" value="Search"></p>      
                        
        </form>
    </div>
 </body>
</html>
