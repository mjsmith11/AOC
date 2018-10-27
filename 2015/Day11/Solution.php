<?php

    // cqjxjnds
    $input = array(18, 3, 13, 9, 23, 9, 16, 2);
    $pass = increment($input);
    while (!containsStraight($pass) || !twoPairs($pass) || containsBannedChars($pass)) {
        $pass = increment($pass);
    }
    $pass2 = increment($pass);
    while (!containsStraight($pass2) || !twoPairs($pass2) || containsBannedChars($pass2)) {
        $pass2 = increment($pass2);
    }
    output($pass);
    echo "\n";
    output($pass2);
    echo "\n";

    function increment($password) {
        $password[0] = $password[0] + 1;
        if ($password[0] > 25) {
            $password[0] = 0;
            $password[1] = $password[1] + 1;
            if ($password[1] > 25) {
                $password[1] = 0;
                $password[2] = $password[2] + 1;
                if ($password[2] > 25) {
                    $password[2] = 0;
                    $password[3] = $password[3] + 1;
                    if ($password[3] > 25) {
                        $password[3] = 0;
                        $password[4] = $password[4] + 1;
                        if ($password[4] > 25) {
                            $password[4] = 0;
                            $password[5] = $password[5] + 1;
                            if ($password[5] > 25) {
                                $password[5] = 0;
                                $password[6] = $password[6] + 1;
                                if ($password[6] > 25) {
                                    $password[6] = 0;
                                    $password[7] = $password[7] + 1;
                                }
                            }
                        }
                    }
                }
            }
        }
        return $password;
    }

    function output($password) {
        echo chr($password[7] + 97);
        echo chr($password[6] + 97);
        echo chr($password[5] + 97);
        echo chr($password[4] + 97);
        echo chr($password[3] + 97);
        echo chr($password[2] + 97);
        echo chr($password[1] + 97);
        echo chr($password[0] + 97);
    }

    function containsStraight($password) {
        $last = 100;
        $seq = 0;
        for ($i=7; $i>=0; $i--) {
            if ($password[$i]-$last == 1) {
                $seq = $seq + 1;
                if ($seq == 3) {
                    return true;
                }
            } else {
                $seq = 1;
            }
            $last = $password[$i];
        }
        return false;
    }

    function twoPairs($password) {
        $pairs = 0;
        $last = 100;
        $check = false;
        for ($i=7; $i>=0; $i--) {
            if ($check) {
                if ($last == $password[$i]) {
                    $pairs = $pairs + 1;
                    $check = false;
                }
            } else {
                $check = true;
            }
            $last = $password[$i];
        }
        return $pairs>=2;
    }

    function containsBannedChars($password) {
        for ($i=7; $i>=0; $i--) {
            if ($password[$i] == 8) { return true; } // i
            if ($password[$i] == 14) { return true; } // o 
            if ($password[$i] == 11) { return true; } // l
        }
        return false;
    }