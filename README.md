AlbumPrinter solution which is built on Onion Architecture with all essential feature using .NET Core!

This project contains following features:

<h3>Application is implemented on Onion architecture</h3>
 <ul>
 <li>RESTful API</li>
 <li>Entityframework Core</li>
 <li>Expection handling</li>
 <li>Automapper</li>
 <li>Unit testing via XUnit</li>
 <li>Swagger UI</li>
 <li>Generic Repository Pattern</li>
 <li>FluentValidation</li>
 <li>Bogus Fake Data Generator</li>
 </ul>
 
 
<h3>Project Description</h3>

We can see that all the Layers are dependent only on the Core Layers

<details>
  <summary><b>Domain layer</b></summary>
  <p dir="auto">
    Domain Layers (Core layer) is implemented in center and never depends on any other layer. Therefore, what we do is that we create entites. 
  </p>
</details>

<details>
  <summary><b>Persistence layer</b></summary>
  <p dir="auto">
    In Persistence layer where we implement reposistory design pattern. In our project, we have implement Entityframework which already implements a repository design pattern. Each DbSet is the repository. This interacts with our database using dataproviders
  </p>
</details>

<details>
  <summary><b>Application layer</b></summary>
  <p dir="auto">
    Application layer (or also called as Service layer) where we can implement business logic. We do validations and mapping stuff here!
  </p>
  <p dir="auto">In case you want to implement email feature logic, we define an IMailService in the Service Layer.
  Using DIP, it is easily possible to switch the implementations. This helps build scalable applications.
  </p>
</details>

<details>
  <summary><b>Common layer</b></summary>
  <p dir="auto">
    Common Functions and Utils are here. Also I put the request and response DTOs in common project. Because we can have multiple presentation layer, so each presentation project uses the same models.
  </p>
</details>

<details>
  <summary><b>Presentation Layer</b></summary>
  <p dir="auto">
    This can be WebApi or UI.
  </p>
</details>

<h3>Project Setup</h3>

<h4>Step 1: Configure connection string</h4>

<p>Please change the connection information with your own connection string!</p>

<p>Change the connection string which is in appsettings.json and AlbelliContext.cs(Persistence Layer) file.</p>

<h4>Step 2: Create Database(Sample is for Microsoft SQL Server)</h4>

<p dir="auto">For Code First approach (To run this application, use Code First apporach)</p>

<ul dir="auto">
<li>
<p dir="auto">For running migration:</p>
<ul dir="auto">
<li>
<p dir="auto">Option 1: Using Package Manager Console:</p>
<ul dir="auto">
<li>Open Package Manager Console, select <em>&lt;&lt; ProjectName &gt;&gt;.Persistence</em> as Default Project</li>
<li>Run these commands:
<div class="highlight highlight-source-shell notranslate position-relative overflow-auto"><pre>PM<span class="pl-k">&gt;</span> add-migration Initial-commit-Application

PM<span class="pl-k">&gt;</span> update-database
    </clipboard-copy>
  </div></div>
</li>
</ul>
</li>
</ul>
</li>
</ul>


<h4>Step 3: Build and run application</h4>

<p>Run the application</p>
