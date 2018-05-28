<?php
    $servername = "localhost";
    $username = "root";
    $password = "";
    $dbName = "connectunity";
    
    //Make Connection
    $conn = new mysqli($servername,$username,$password,$dbName);
    //Check Connection
    if(!$conn){
        die("Connection Failed!".mysqli_connect_error());
    }
    
    $sql="SELECT PosIndex,Pos_X,Pos_Y,Pos_Z FROM locationinfo";
    $result = mysqli_query($conn,$sql);

    if(mysqli_num_rows($result)>0){
    //show data for each row
       while($row =mysqli_fetch_assoc($result)){
         //  echo "PosIndex:".$row['PosIndex']."|Pos_X:".$row['Pos_X']."|Pos_Y:".$row['Pos_Y']."|Pos_Z:".$row['Pos_Z'].";";
             echo $row['Pos_X']."|".$row['Pos_Y']."|".$row['Pos_Z'].";";
       }
    }
?>