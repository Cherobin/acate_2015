<?php

class Company {
    public $id;
    public $name;
    public $description;
    public $logo;
    public $link;
    public $qrcode;
    public $posX;
    public $posY;
    
    public function __construct($row = null) {
        if($row != null){
            $this->id = (int)$row['id'];
            $this->name = $row['name'];
            $this->description = $row['description'];
            $this->logo = $row['logo'];
            $this->link = $row['link'];
            $this->qrcode = $row['qrcode'];
            $this->posX = (int)$row['pos_x'];
            $this->posY = (int)$row['pos_y'];
        }
    }
}
