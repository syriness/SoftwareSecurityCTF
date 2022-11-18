<?php
session_start();
?>

<!DOCTYPE HTML>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>Login</title>
  <link href="login.css" rel="stylesheet">
</head>
<body>
  <?php
  $retval = 0;
  $_SESSION["login"] = 0;
  if($_SERVER["REQUEST_METHOD"] == "POST") {
    $login = $_POST['username'];
    $pass = $_POST['password'];
    $login = preg_replace('/[^A-Za-z0-9 ]/', '', $login);
    $pass = preg_replace('/[^A-Za-z0-9 ]/', '', $pass);
    
    //construct command which will be passed to exec
    $argument = "./login '{$login}' '{$pass}'";
    
    // call login.c with entered id and password
    exec($argument, $voted, $retval);
  }
  ?>
  <div class="content-box">
  <form class="box" action=<?php echo htmlspecialchars($_SERVER['PHP_SELF']);?> method="POST">
  <div>
  <a href="../mainpage.html"><img  src="logo.png" alt="" height="300"></a>
  </div>
      <div class="user-box">
        <label>Username</label>
        <input type="text" name="username" placeholder="Enter Username">
      </div>
      <div class="user-box">
        <label>Password</label>
        <input type="password" name="password" placeholder="Password">
      </div>
      <div>
        <input type="submit" value="Login">
</div>
    </form>
    
    <?php
    // check whether login was successful
    // login.c returns 11 if successful, 12 otherwise
    if($retval == 10 or $retval == 11) {
      echo '<div class="info">Login success!</div>';
      $_SESSION["login"] = 1;
      $_SESSION["username"] = $login;
      $_SESSION["pass"] = $pass;
      $_SESSION["voted"] = $voted[0];
      header("Location: main.php");
    }
    else if ($retval == 12) {
      $_SESSION["connected"] = 0;
      echo $login;
      echo '<br>IS NOT USER!';
    }
    ?>
  </div> 
</body>
</html>
