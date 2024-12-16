This is Arithmetic Trainer, a console app for practising basic arithmetic.

Choose a training activity:

```txt
Welcome to Arithmetic Trainer
Select Action:            
                          
> Start Fixed Time Test   
  Start Fixed Length Test 
  Start Practice          
  View Training History   
  Quit         
```

Choose a problem collection:

```txt
Choose Problem Collection:                            
                                                      
> Mixed (+-/*) On Interval From 2 To 99               
  Mixed (+-/*) On Interval From -20 To 20             
  Addition & Subtraction On Interval From -999 To 999 
  Cancel
```

Train with fixed time tests:

```txt
Starting 15 seconds Test on Mixed (+-/*) On Interval From 2 To 99.
80 - 3 = ?
77
Correct. Time Remaining: 14 seconds
40 / 4 = ?
10
Correct. Time Remaining: 12 seconds
56 / 2 = ?
28
Correct. Time Remaining: 10 seconds
28 / 2 = ?
14
Correct. Time Remaining: 9 seconds
5 + 3 = ?
8
Correct. Time Remaining: 7 seconds
11 * 5 = ?
55
Correct. Time Remaining: 6 seconds
66 / 6 = ?
11
Correct. Time Remaining: 4 seconds
2 * 2 = ?
4
Correct. Time Remaining: 3 seconds
4 * 23 = ?
93
Time's up
Correct Count: 8 Incorrect Count: 0
Try Again? [y/n] (y): n
```

Train with fixed length tests:

```txt
Starting 10 Problems Test on Mixed (+-/*) On Interval From -20 To 20.
-18 / (-1) = ?
10
Incorrect. The answer is 18. Problems Remaining: 9
3 * 6 = ?
18
Correct. Problems Remaining: 8
0 + (-15) = ?
-15
Correct. Problems Remaining: 7
16 - 4 = ?
12
Correct. Problems Remaining: 6
12 + (-1) = ?
11
Correct. Problems Remaining: 5
-10 - (-19) = ?
9
Correct. Problems Remaining: 4
3 - 5 = ?
-2
Correct. Problems Remaining: 3
-5 + 20 = ?
15
Correct. Problems Remaining: 2
3 - (-5) = ?
8
Correct. Problems Remaining: 1
-16 / (-2) = ?
8
Correct. Problems Remaining: 0
Finish Time: 00:33 (including 00:10 penalty time)
Try Again? [y/n] (y): n
```

Practice at one's own pace:

```txt
Starting Practice on Addition & Subtraction On Interval From -999 To 999. Press q to stop.
372 - (-322) = ?
694
Correct
560 - 473 = ?
87
Correct
23 + (-988) = ?
-965
Correct
-809 - (-101) = ?
q
```

View the training history:

```txt
┌──────────────────┬──────────┬─────────────────────────────┐
│ Question         │ Response │ Outcome                     │
├──────────────────┼──────────┼─────────────────────────────┤
│ 80 - 3 = ?       │ 77       │ Correct                     │
│ 40 / 4 = ?       │ 10       │ Correct                     │
│ 56 / 2 = ?       │ 28       │ Correct                     │
│ 28 / 2 = ?       │ 14       │ Correct                     │
│ 5 + 3 = ?        │ 8        │ Correct                     │
│ 11 * 5 = ?       │ 55       │ Correct                     │
│ 66 / 6 = ?       │ 11       │ Correct                     │
│ 2 * 2 = ?        │ 4        │ Correct                     │
│ -18 / (-1) = ?   │ 10       │ Incorrect. The answer is 18 │
│ 3 * 6 = ?        │ 18       │ Correct                     │
│ 0 + (-15) = ?    │ -15      │ Correct                     │
│ 16 - 4 = ?       │ 12       │ Correct                     │
│ 12 + (-1) = ?    │ 11       │ Correct                     │
│ -10 - (-19) = ?  │ 9        │ Correct                     │
│ 3 - 5 = ?        │ -2       │ Correct                     │
│ -5 + 20 = ?      │ 15       │ Correct                     │
│ 3 - (-5) = ?     │ 8        │ Correct                     │
│ -16 / (-2) = ?   │ 8        │ Correct                     │
│ 372 - (-322) = ? │ 694      │ Correct                     │
│ 560 - 473 = ?    │ 87       │ Correct                     │
│ 23 + (-988) = ?  │ -965     │ Correct                     │
└──────────────────┴──────────┴─────────────────────────────┘
```