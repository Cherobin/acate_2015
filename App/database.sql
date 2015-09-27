-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema acate
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema acate
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `acate` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `acate` ;

-- -----------------------------------------------------
-- Table `acate`.`company`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `acate`.`company` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT COMMENT '',
  `name` VARCHAR(45) NOT NULL COMMENT '',
  `description` VARCHAR(512) NOT NULL COMMENT '',
  `logo` VARCHAR(50) NOT NULL COMMENT '',
  `link` VARCHAR(128) NOT NULL COMMENT '',
  `qrcode` VARCHAR(128) NOT NULL COMMENT '',
  `pos_x` INT NOT NULL COMMENT '',
  `pos_y` INT NOT NULL COMMENT '',
  PRIMARY KEY (`id`)  COMMENT '',
  UNIQUE INDEX `name_UNIQUE` (`name` ASC)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `acate`.`room`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `acate`.`room` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT COMMENT '',
  `name` VARCHAR(45) NOT NULL COMMENT '',
  `qrcode` VARCHAR(128) NOT NULL COMMENT '',
  `chairs` INT NOT NULL COMMENT '',
  PRIMARY KEY (`id`)  COMMENT '',
  UNIQUE INDEX `name_UNIQUE` (`name` ASC)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `acate`.`agenda`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `acate`.`agenda` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT COMMENT '',
  `room_id` INT UNSIGNED NOT NULL COMMENT '',
  `date_start` DATETIME NOT NULL COMMENT '',
  `date_finish` DATETIME NOT NULL COMMENT '',
  `owner` VARCHAR(45) NOT NULL COMMENT '',
  PRIMARY KEY (`id`)  COMMENT '',
  INDEX `fk_agenda_room_idx` (`room_id` ASC)  COMMENT '',
  CONSTRAINT `fk_agenda_room`
    FOREIGN KEY (`room_id`)
    REFERENCES `acate`.`room` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
