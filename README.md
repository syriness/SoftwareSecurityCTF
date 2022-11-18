Software security GitCTF
========================
Ubuntu Version: 16.04 LTS

# 0. Update & Install
-------------------

<pre>
<code>
$sudo apt-get update
$sudo apt-get upgrade
$sudo apt-get install apache2
$sudo apt-get install mysql-server
Set root password: 1111
</code>
</pre>

<pre>
<code>
$sudo apt-get install libmysql++-dev
$sudo apt-get install mysql-client mysql-server
$sudo apt-get install php7.0  
$sudo apt-get install apache2 php7.0 libapache2-mod-php7.0
</pre>
</code>

# 1. Setting Mysql
-------------------
<pre>
<code>
$sudo mysql_secure_installation
Enter the password: 1111
Answer: N, N, Y, Y, Y, Y

$mysql -u root -p  
CREATE DATABASE Wiki;
exit
$mysql -u root -p Wiki < base.sql
</code>
</pre>

# 2. Setting Apache2
-------------------
<pre>
<code>
$cd /etc/  
$sudo gedit hosts
</code>
</pre>
Below the line that says 127.0.0.1 localhost, copy and paste the following:
<pre>
<code>
127.0.0.1 wiki.gitctf  
</code>
</pre>
Save and exit gedit.
<pre>
<code>
$sudo mkdir -p /var/www/wiki
$sudo chown -R $USER:$USER /var/www/wiki
$sudo chmod -R 755 /var/www  
$sudo cp /etc/apache2/sites-available/000-default.conf /etc/apache2/sites-available/wiki.conf  
$sudo gedit /etc/apache2/sites-available/wiki.conf  
</code>
</pre>
Change between <VirtualHost *:80> and \</VirtualHost> as follows:
<pre>
<code>
<VirtualHost *:80>  
   ServerName wiki.gitctf  
   ServerAdmin admin@wiki.gitctf  
   DocumentRoot /var/www/wiki
   ErrorLog ${APACHE_LOG_DIR}/error.log  
   CustomLog ${APACHE_LOG_DIR}/access.log combined  
</VirtualHost>
</code>
</pre>
Save and exit gedit.
<pre>
<code>
$sudo a2ensite wiki.conf  
$systemctl reload apache2  
$sudo apt-get install libmysqlclient-dev  
</code>
</pre>

# 3. Complie & Execute
--------------------
All downloaded files move to the /var/www/wiki directory
<pre>
<code>
$cd /var/www/wiki
$sudo touch poc.txt
$sudo chown www-data /var/www/wiki/poc.txt
$gcc -z execstack -fno-stack-protector -z norelro -g -O0 -o login login.c -I/usr/include/mysql -lmysqlclient -L/usr/lib
$gcc -z execstack -fno-stack-protector -z norelro -g -O0 -o DocumentEdit DocumentEdit.c -I/usr/include/mysql -lmysqlclient -L/usr/lib 
$gcc -z execstack -fno-stack-protector -z norelro -g -O0 -o search2 search2.c -I/usr/include/mysql -lmysqlclient -L/usr/lib 
</code>
</pre>
After compling, You can now access by opening 'http://wiki.gitctf/main.php' in your browser.
