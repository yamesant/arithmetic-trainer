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
Pick a training mode:

```txt
Pick Training Mode:                   
                                      
> Mixed (+-/*) On Range 2 to 99       
  Addition (+) On Range 2 to 99       
  Subtraction (-) On Range 2 to 99    
  Division (/) On Range 2 to 99       
  Multiplication (*) On Range 2 to 99 
  Cancel      
```

Train with fixed time tests:

```txt
Starting 15 seconds Test on Mixed (+-/*) On Range 2 to 99.
96 / 2 = ?
48
Correct. Time Remaining: 13 seconds
86 / 2 = ?
43
Correct. Time Remaining: 11 seconds
92 - 4 = ?
88
Correct. Time Remaining: 9 seconds
16 + 17 = ?
33
Correct. Time Remaining: 8 seconds
26 + 32 = ?
58
Correct. Time Remaining: 5 seconds
26 * 2 = ?
25
Incorrect. The answer is 52. Time Remaining: 4 seconds
5 * 14 = ?
70
Correct. Time Remaining: 2 seconds
9 * 3 = ?
27
Time's up
Correct Count: 6 Incorrect Count: 1
Try Again? [y/n] (y): n
```

Train with fixed length tests:

```txt
Starting 10 Problems Test on Subtraction (-) On Range 2 to 99.
83 - 22 = ?
61
Correct. Problems Remaining: 9
38 - 6 = ?
32
Correct. Problems Remaining: 8
91 - 11 = ?
80
Correct. Problems Remaining: 7
51 - 14 = ?
37
Correct. Problems Remaining: 6
29 - 20 = ?
1
Incorrect. The answer is 9. Problems Remaining: 5
36 - 27 = ?
9
Correct. Problems Remaining: 4
92 - 34 = ?
58
Correct. Problems Remaining: 3
92 - 13 = ?
79
Correct. Problems Remaining: 2
98 - 35 = ?
63
Correct. Problems Remaining: 1
81 - 59 = ?
22
Correct. Problems Remaining: 0
Finish Time: 00:37 (including 00:10 penalty time)
Try Again? [y/n] (y): n
```

Practice at one's own pace:

```txt
Starting Practice on Multiplication (*) On Range 2 to 99. Press q to stop.
3 * 5 = ?
15
Correct
22 * 4 = ?
88
Correct
7 * 7 = ?
q
```

View the training history:

```txt
┌─────────────┬──────────┬─────────────────────────────┐
│ Question    │ Response │ Outcome                     │
├─────────────┼──────────┼─────────────────────────────┤
│ 96 / 2 = ?  │ 48       │ Correct                     │
│ 86 / 2 = ?  │ 43       │ Correct                     │
│ 92 - 4 = ?  │ 88       │ Correct                     │
│ 16 + 17 = ? │ 33       │ Correct                     │
│ 26 + 32 = ? │ 58       │ Correct                     │
│ 26 * 2 = ?  │ 25       │ Incorrect. The answer is 52 │
│ 5 * 14 = ?  │ 70       │ Correct                     │
│ 83 - 22 = ? │ 61       │ Correct                     │
│ 38 - 6 = ?  │ 32       │ Correct                     │
│ 91 - 11 = ? │ 80       │ Correct                     │
│ 51 - 14 = ? │ 37       │ Correct                     │
│ 29 - 20 = ? │ 1        │ Incorrect. The answer is 9  │
│ 36 - 27 = ? │ 9        │ Correct                     │
│ 92 - 34 = ? │ 58       │ Correct                     │
│ 92 - 13 = ? │ 79       │ Correct                     │
│ 98 - 35 = ? │ 63       │ Correct                     │
│ 81 - 59 = ? │ 22       │ Correct                     │
│ 3 * 5 = ?   │ 15       │ Correct                     │
│ 22 * 4 = ?  │ 88       │ Correct                     │
└─────────────┴──────────┴─────────────────────────────┘
```