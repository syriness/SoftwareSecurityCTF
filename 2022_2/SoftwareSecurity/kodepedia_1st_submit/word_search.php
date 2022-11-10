<?php
 session_start();
 $search = $_POST['searching'];
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Searching report</title>
</head>

<body>
  <?php
    //construct command which will be passed to exec
  $retval = 0;
  $argument = "./search2 '{$search}'";
    
    // call login.c with entered id and password
  $night = exec($argument);;
  ?>
<h1>Result</h1>
<?php
      
      echo("$night");
    
    ?>
<p></p>      
<button class = "go_main" onclick="location.href='main.php'">Return Main</button>
</body>

</html>
