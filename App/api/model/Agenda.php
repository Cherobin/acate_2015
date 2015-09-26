<?php

class Agenda {
    public $id;
    public $roomId;
    public $dateStart;
    public $dateFinish;
    public $owner;
    
    public function __construct($row = null) {
        if($row != null){
            $this->id = (int)$row['id'];
            $this->roomId = (int)$row['room_id'];
            $this->dateStart = $row['date_start'];
            $this->dateFinish = $row['date_finish'];
            $this->owner = $row['owner'];
        }
    }
}
