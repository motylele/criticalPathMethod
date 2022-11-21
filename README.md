# Critical Path Method

CPM algorithm for an AN newtork (activity on nodes).
* User enters tasks/ AN network
* program check whether the given digraph is acyclic
* program for each task calculates the earliest and latest start time of the task
* shows the order of tasks (Gantt schedule)

## Input specification
In the first line of standard input user enters the number of tasks (nodes). Then we specify every node name, its duration $(>0)$, number of the direct ancestors and names of their nodes (ancestors must be first added as a node to be ancestor of something, this prevents the formation of cycles, **also first node can't have any ancestor**).

## Output specification
The program simulates the CPM algorithm and returns the names of the nodes in the order
in which the critical path was created. The earliest start (es), latest start (ls), earliest end (ee),
latest end (le) of each node is also calucalted). Finally, the Gantt schedule is displayed.

## Example
![Screenshot](example.jpg)

### Input
6 </br>
A </br>
5 </br>
B </br>
3 </br>
1 </br>
A </br>
C </br>
3 </br>
2 </br>
A </br>
B </br>
D </br>
1 </br>
2 </br>
B </br>
C </br>
E </br>
2 </br>
2 </br>
C </br>
D </br>
F </br>
3 </br>
2 </br>
D </br>
E </br>

### Output
A B C D E F </br>
C max = 17 </br>
A: es=0, ls=0, ee=5, le=5 </br>
B: es=5, ls=5, ee=8, le=8 </br>
C: es=8, ls=8, ee=11, le=11 </br>
D: es=11, ls=11, ee=12, le=12 </br>
E: es=12, ls=12, ee=14, le=14 </br>
F: es=14, ls=14, ee=17, le=17 </br>
Gantt schedule:  </br>
M1: |0:5|A |5:8|B |8:11|C |11:12|D |12:14|E |14:17|F </br>


