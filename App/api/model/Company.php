<?php

class Company {
    public $id;
    public $name;
    public $description;
    public $logo;
    public $link;
    public $qrcode;
    
    public function __construct($row = null) {
        if($row != null){
            $this->id = (int)$row['id'];
            $this->name = $row['name'];
            $this->description = $row['description'];
            $this->logo = $row['logo'];
            $this->link = $row['link'];
            $this->qrcode = $row['qrcode'];
        }
    }
}
