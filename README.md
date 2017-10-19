# StringTest

<p>Compare String function for the best Performance</p>
<p>All Test are made with a String of a 1 MB Size.</p>
<p>Every test function will add the String 50 times together and this will be repeated 20 times per function.</p>
</br>
</br>

<p>Test Environment</p>
<p>CPU: Intel i7 6900K @ 4.29 GHz</p>
<p>MEM: 64 GB</p>
<p>SSD: Samsung 850 Pro NVE</p>
<p>Windows 10 Pro (latest updates @ 19.10.2017)</p>

</br>
</br>
<b>Test .Net Framework 4.0</b>
<table>
  <tr>
    <th>Function</th>
    <th>avg MS</th>
    <th>min MS</th>
    <th>max MS</th>
    <th>max Memory (MB)</th>
  </tr>
  <tr>
    <td>String3</td>
    <td>23</td>
    <td>18</td>
    <td>35</td>
    <td>623.5</td>
  </tr>
   <tr>
    <td>String7</td>
    <td>24</td>
    <td>18</td>
    <td>31</td>
    <td>513.6</td>
  </tr>
  <tr>
    <td>String9</td>
    <td>24</td>
    <td>23</td>
    <td>25</td>
    <td>224.6</td>
  </tr>
  <tr>
    <td>String11</td>
    <td>24</td>
    <td>23</td>
    <td>25</td>
    <td>224.6</td>
  </tr>
  <tr>
    <td>String8</td>
    <td>24</td>
    <td>23</td>
    <td>25</td>
    <td>224,6</td>
  </tr>
  <tr>
    <td>String10</td>
    <td>24</td>
    <td>23</td>
    <td>25</td>
    <td>224.6</td>
  </tr>
  <tr>
    <td>String2</td>
    <td>331</td>
    <td>329</td>
    <td>335</td>
    <td>228.3</td>
  </tr>
  <tr>
    <td>String1</td>
    <td>332</td>
    <td>326</td>
    <td>343</td>
    <td>228.2</td>
  </tr>
  <tr>
    <td>String5</td>
    <td>335</td>
    <td>329</td>
    <td>341</td>
    <td>521.4</td>
  </tr>
  <tr>
    <td>String4</td>
    <td>662</td>
    <td>644</td>
    <td>675</td>
    <td>896.4</td>
  </tr>
</table>
</br>
</br>
<b>Test .Net Core 2.0</b>
<table>
  <tr>
    <th>Function</th>
    <th>avg MS</th>
    <th>min MS</th>
    <th>max MS</th>
    <th>max Memory (MB)</th>
  </tr>
  <tr>
    <td>String10</td>
    <td>24</td>
    <td>22</td>
    <td>24</td>
    <td>221.3</td>
  </tr>
  <tr>
    <td>String8</td>
    <td>24</td>
    <td>22</td>
    <td>24</td>
    <td>221.3</td>
  </tr>
   <tr>
    <td>String11</td>
    <td>24</td>
    <td>23</td>
    <td>24</td>
    <td>221.3</td>
  </tr>
  <tr>
    <td>String9</td>
    <td>24</td>
    <td>23</td>
    <td>27</td>
    <td>221.3</td>
  </tr>
  <tr>
    <td>String7</td>
    <td>24</td>
    <td>18</td>
    <td>37</td>
    <td>618.2</td>
  </tr>
  <tr>
    <td>String3</td>
    <td>24</td>
    <td>18</td>
    <td>37</td>
    <td>618.2</td>
  </tr>
  <tr>
    <td>String5</td>
    <td>332</td>
    <td>326</td>
    <td>339</td>
    <td>516</td>
  </tr>
  <tr>
    <td>String1</td>
    <td>335</td>
    <td>326</td>
    <td>339</td>
    <td>222.7</td>
  </tr>
  <tr>
    <td>String2</td>
    <td>337</td>
    <td>332</td>
    <td>339</td>
    <td>222.8</td>
  </tr>
  <tr>
    <td>String4</td>
    <td>667</td>
    <td>663</td>
    <td>674</td>
    <td>516.5</td>
  </tr>
</table>
</br>
</br>
<p><i>*MS = Milliseconds</i></p>
<p><i>look in the Source Files to see how the string functions are implemented</i></p>
