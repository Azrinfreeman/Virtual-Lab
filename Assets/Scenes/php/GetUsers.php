<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname= "vlab";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
echo "Connected successfully\n";

$sql = "Select * from `Users`";

$result = $conn->query($sql);

if($result->num_rows > 0){
    while($row = $result->fetch_assoc()){
        echo "name: ". $row["name"]. " password: ". $row["password"]. " email: ". $row["email"];
    }
}else{
    echo "no result";
}
?>