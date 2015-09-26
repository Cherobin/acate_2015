<?php

class CompanyController {
    
    function insert($company, $logo){
        $target_dir = "upload";
        
//        $target_file = $target_dir . basename($logo["name"]);
        $target_file = sprintf('%s/%s.%s', $target_dir, uniqid(), pathinfo($logo['name'], PATHINFO_EXTENSION));
        $uploadOk = 1;
        $imageFileType = pathinfo($target_file, PATHINFO_EXTENSION);
        
        $check = getimagesize($logo["tmp_name"]);
        if($check !== false) {
            echo "File is an image - " . $check["mime"] . ".";
            $uploadOk = 1;
        } else {
            echo "File is not an image.";
            $uploadOk = 0;
        }
        
        if (file_exists($target_file)) {
            echo "Sorry, file already exists.";
            $uploadOk = 0;
        }
        // Check file size
        if ($logo["size"] > 500000) {
            echo "Sorry, your file is too large.";
            $uploadOk = 0;
        }
        // Allow certain file formats
        if($imageFileType != "jpg" && $imageFileType != "png" && $imageFileType != "jpeg"
        && $imageFileType != "gif" ) {
            echo "Sorry, only JPG, JPEG, PNG & GIF files are allowed.";
            $uploadOk = 0;
        }
        // Check if $uploadOk is set to 0 by an error
        if ($uploadOk == 0) {
            echo "Sorry, your file was not uploaded.";
        // if everything is ok, try to upload file
        } else {
            if (move_uploaded_file($logo["tmp_name"], $target_file)) {
                echo "The file ". basename($logo["name"]). " has been uploaded.";
            } else {
                echo "Sorry, there was an error uploading your file.";
            }
        }
        
        $dao = new CompanyDao();
        $nextId = $dao->nextId();
        
        $company->logo = $target_file;
        $company->qrcode = $target_dir.'/qrcode/'.uniqid().'.png';
        
        QRcode::png(BASE_URL.'/company/'.$nextId, $company->qrcode); 
        
        $dao->insert($company);
    }
    
    function listAll(){
        $dao = new CompanyDao();
        return $dao->listAll();
    }
    
}
