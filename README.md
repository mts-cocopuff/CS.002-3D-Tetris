<div align="center">
<h1>
  3D Tetris Shuffle
</h1>
  
<h3 align="center">
  2024-2025 Senior Capstone project at Oregon State University
</h3>
  
<img width="866" alt="Screenshot 2025-05-16 at 5 18 23 PM" src="https://github.com/user-attachments/assets/325aa74f-9bae-43c4-94b2-020f80a33602" />

</div>
<!-- Insert team photo -->

## 

<details padding=10px>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a>About The Project</a>
      <ul>
        <li><a>Team Members</a></li>
        <li><a>Development Timeline</a></li>
      </ul>
    </li>
    <li>
      <a>Project Motivation</a>
    </li>
    <li><a>Development and Technology Used</a></li>
    <li><a>Installation and Dependencies</a></li>
    <li><a>Contact</a></li>
  </ol>
</details>



<h1>❓ About</h1>

<p>In order to install this application there are a few requirements you need
such as a Meta Quest 3, Access to a device that you can connect to the quest 3 using a cord, and the Side Quest Application to install the .apk file to the headset. Further details about the process are added below </p>

[⬇️ Download APK File](https://github.com/mts-cocopuff/CS.002-3D-Tetris/tree/main/BuiltAPKversions/TetrisShuffle1.0.apk)

<h3>Requirements</h3>
<p><p>
<ul>
  <li>Meta Quest 3 Headset</li>
  <ul>
    <li>The headset that you use must be set to developer mode. To learn how to do that, click the link below.</li>
    <li><a href="https://medium.com/sidequestvr/how-to-turn-on-developer-mode-for-the-quest-3-509244ccd386">Developer Mode Tutorial</a></li>
  </ul>
  <li>Side Quest Application to load APK to headset</li>
   <ul>
    <li><a href="https://sidequestvr.com/">Side Quest</a></li>
  </ul>
  <li>Computer or device to connect to the Quest 3</li>
  <li>A wire (USB-C cable) to connect to the Quest 3 device</li>
</ul>

<h3>Steps for Installing program to Quest 3</h3>
<p></p>
<ol>
  <li>Create a Meta Account if you do not have one or locate the one associated with your headset</li>
  <li>Log into meta dashboard at <a href="https://developer.oculus.com/manage/organizations/149461441410610/">https://developer.oculus.com</a> and follow previously mentioned instructions for enabling developer mode</li>
  <li>Set Quest 3 Headset to Developer Mode as described in listed manuals</li>
  <li>Install  <a href="https://sidequestvr.com/">Side Quest</a> application to install .apk file to headset</li>
  <li>Connect Meta Quest 3 to computer or device and allow debugging inside headset</li>
  <li>Open Side Quest with headset connected and look for a green circle in the top left that indicates that a connection is established to the headset</li>
  <li>In the icons in the top right corner of the application, click the icon that looks like a box with a down arrow on it</li>
  <li>Select the .apk file to upload to headset </li>
  <li>If the operation finishes without errors, then the application should be loaded to a file called unknown applications in the headset</li>
  <li>Look at your application library in the meta quest 3 and there should either be a tab called "Unknown Sources" or a dropdown menu that contains a section that is called unknown sources, this is where the application should be installed to</li>
  <li>Click on the application to launch it</li>
</ol>



<h2>👥 Meet the Team Members</h2>
<ul>
  <li><strong>Alex Giger</strong> – Team Captain, Developer</li>
  <li><strong>Rebecca Klump</strong> - Game Design Lead, Developer</li>
  <li><strong>Sage Tafoya</strong> – XR Development Lead</li>
  <li><strong>Kimberly Yeo</strong> - Documentation Review, Developer</li>
  <li><strong>Mike Bailey</strong> – Project Partner</li>
</ul>



<h2>📅 Development Timeline</h2>
<ul style="list-style: none; padding-left: 0;">
  <li><strong> Fall 2024:</strong> Planning Phase – brainstorming, research, and design mockups.</li>
  <li><strong> Winter 2025:</strong> Implementation Phase – core development and design revision.</li>
  <li><strong> Spring 2025:</strong> Finalization – polishing, bug fixes, and product launch.</li>
</ul>

<img width="866" alt="Screenshot" src="https://github.com/user-attachments/assets/f33954bb-6810-4ca1-9f10-e7a11ee2b032" />



<h1>Project Motivation</h1>

<h2>✅ Our Problem Statement</h1>
<p>
  A problem with introducing augmented reality (AR) technology to people is that the features of it are often new and hard to present in an intuitive manner.

  One feature of augmented reality that we showcase is how interacting with a real physical objects affect virtual objects in a 3D environment, creating a more immersive experience than other fully virtual projects.

  In our project, AR is also contextualized by a familiar setting - Tetris. All of these factors combined make for an engaging experience that helps the user become more familiar with AR technology.
</p>



<h2>🧑‍🧑‍🧒 Audience</h2>
<p>
  Our project aims to captivate people of all ages, reflecting the addictive and widespread nature of Tetris. As what was stated in our problem statement, we wanted to focus on people with little or no experience using Augmented/Virtual Reality.

  Given the fact that the main audience for Virtual Reality games are younger people, we wanted to focus on making the gameplay and controls intuitive so that players can pick up the game without looking at a tutorial.
</p>



<h2>⚙️ Core Features</h2>
<li>Realistic piece physics</li>
<li>Playing field rotation linked to one controller</li>
<li>Piece rotation and movement tracked with other controller</li>
<li>Scoring mechanic based on color matching</li>
<li>High score leaderboard to compete against others!</li>



<h2>🔌 Implementation</h2>
<li>Unity version 2022.3.52f1</li>
<li>Uses Meta Quest 3 and OpenXR plugin</li>
<li>Synchronizes rotation of controller and rotation of game board</li>
<li>Has to sync up controller movements with Unity physics</li>

