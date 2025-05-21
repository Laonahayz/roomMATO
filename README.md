<h1 style="font-size: 28px;">roomMATO - 2D解謎遊戲</h1>

<p>roomMATO是由<strong>匿名工作室</strong>開發的解謎遊戲，主打「從不同觀察角度切換來解謎」的創新機制。遊戲中，玩家將在立方體房間中，切換兩個對角觀察視角來獲取線索、發現道具與觸發機關，藉此推進遊戲進度。整體遊戲強調空間理解與觀察思維的轉換。</p>

<h2 style="font-size: 20px;">系統畫面展示</h2>
<p>點擊圖片觀看實際展示影片</p>
<a href="https://youtu.be/vqLbVmRgCY8">
  <img src="Assets/Images/roomMATO_Screenshot.png" alt="點擊觀看展示影片" width="600" />
</a>

<h2>專案用途</h2>
<p>
本專案為 Unity 製作的2D單人解謎遊戲作品，展示以下遊戲設計與開發能力：
</p>
<ul>
  <li>視角切換系統設計與實作</li>
  <li>多房間場景與互動邏輯規劃</li>
  <li>物件狀態轉換與提示邏輯</li>
  <li>整合 <strong>Fungus</strong> 套件進行對話與事件流程控制</li>
  <li>敘事與視覺導引的整合</li>
</ul>

<h2>操作方式</h2>
<ol>
  <li>玩家可在場景中切換觀察視角</li>
  <li>視角為固定的房間對角觀察點，切換後能從不同角度看到角色與場景中的線索</li>
  <li>透過觀察視角差異，發現道具、觸發機關或解開謎題，進而推進關卡</li>
</ol>

<h2>開發工具</h2>
<ul>
  <li>Unity 2019.4.3f1</li>
  <li>C# / Unity API</li>
  <li><strong>Fungus</strong>（視覺化流程與對話控制套件）</li>
</ul>

<h2>專案結構說明</h2>
<ul>
  <li><strong>ViewManager.cs</strong>：處理視角切換與控制邏輯</li>
  <li><strong>RoomManager.cs</strong>：管理每個場景與解謎條件</li>
  <li><strong>HintSystem.cs</strong>：提示邏輯與玩家互動引導</li>
  <li><strong>ItemController.cs</strong>：道具取得與狀態管理</li>
  <li><strong>Fungus Flowcharts</strong>：管理各房間事件、對話與解謎流程</li>
</ul>

<h2>製作團隊</h2>
<p><strong>匿名工作室（大學畢業製作團隊）</strong></p>
<ul>
  <li><strong>我：</strong>場景建置、角色動畫、介面互動、遊戲介紹流程設計、提示系統開發</li>
</ul>

<h2>⚠️ 注意事項</h2>
<ul>
  <li>若使用 Fungus 對話時有中文亂碼，請確認字體支援或自行更換中文字型</li>
</ul>
