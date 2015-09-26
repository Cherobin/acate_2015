<?php

class Room {
    public $id;
    public $name;
    public $qrcode;
    public $chairs;
    
    public function __construct($row = null) {
        if($row != null){
            $this->id = (int)$row['id'];
            $this->name = $row['name'];
            $this->qrcode = $row['qrcode'];
            $this->chairs = (int)$row['chairs'];
        }
    }
}
