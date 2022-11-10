<?php
 session_start();
 $color = $_POST['co'];
 $sport = $_POST['sp'];
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Post Article</title>
</head>

<body>
  <?php
  $retval = 0;
    //construct command which will be passed to exec
  $argument = "./DocumentEdit '{$color}' '{$sport}'";
    
    // call login.c with entered id and password
  $bca = exec($argument, $voted, $retval);
  ?>
<h1>Adding the Article...</h1>
<p>article: <?php echo $color ?>.</p>
<p>decription: <?php echo $sport ?>.</p>          
<button class = "go_main" onclick="location.href='main.php'">Return Main</button>
</body>

</html>
