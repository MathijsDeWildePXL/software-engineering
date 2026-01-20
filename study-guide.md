# Software Engineering Study Guide

## Module 1 - DevOps

### What is DevOps?

**Definition**: DevOps is a set of practices, tools, and a cultural philosophy that aims to shorten the software development lifecycle and provide continuous delivery with high software quality.

- Patrick Debois

**Origin**: DevOps emerged around 2007-2008 as a response to the conflict between development and operations teams. It combines "Development" and "Operations" to break down silos.

**Necessity**:
- Traditional siloed organizations: Development and Operations worked separately, causing friction and slow deployments
- Need for faster delivery of features and fixes
- Requirement for higher reliability and stability in production
- Cost reduction through automation
- Better collaboration and communication between teams

### DevOps Principles

1. **Collaboration**: Break down silos between development and operations teams
2. **Automation**: Automate repetitive tasks (builds, tests, deployments)
3. **Measurement**: Monitor and measure everything to enable data-driven decisions
4. **Sharing**: Share knowledge, failures, and successes across teams
5. **Continuous Improvement**: Constantly iterate and improve processes
6. **Customer-Centric**: Focus on delivering value to customers

### Microsoft's Vision (Donovan Brown)

**Donovan Brown's Definition**: "DevOps is the union of people, process, and products to enable continuous delivery of value to our end users."

**Key Points**:
- Focus on continuous delivery and value
- Emphasizes people and culture, not just tools
- Integrates development and operations

### Amazon's Perspective

- **Two-pizza teams**: Teams should be small enough that they can be fed with two pizzas
- **You build it, you run it**: Developers are responsible for their code in production
- **Automation first**: Extensive use of Infrastructure as Code (IaC)
- **Data-driven decisions**: Continuous monitoring and metrics

### Similarities and Differences

| Aspect | Microsoft | Amazon |
|--------|-----------|--------|
| **Focus** | Continuous delivery of value | Operational excellence |
| **Team Structure** | Collaborative | Autonomous small teams |
| **Culture** | People-centric | Accountability-focused |
| **Tools** | Azure DevOps suite | Custom internal tools, AWS services |
| **Shared** | Automation, Measurement, Collaboration | Automation, Ownership, Data-driven |

### Azure DevOps

**What is it?**: A comprehensive platform providing tools for planning, developing, deploying, and operating software projects.

**Purpose**: Enable DevOps practices by providing integrated tools across the entire development lifecycle.

**Main Components**:

1. **Azure Boards**: Project planning and tracking
   - Work items (user stories, tasks, bugs)
   - Backlogs, sprints, dashboards
   - Integration with version control

2. **Azure Repos**: Version control system
   - Git repositories
   - Pull requests and code reviews
   - Branch policies

3. **Azure Pipelines**: CI/CD automation
   - Build pipelines (Continuous Integration)
   - Release pipelines (Continuous Deployment)
   - Multi-platform support

4. **Azure Artifacts**: Package management
   - Store and manage packages (NuGet, npm, Python, etc.)
   - Artifact feeds

5. **Azure Test Plans**: Test management
   - Test case management
   - Test execution tracking
   - Integration with pipelines

### Azure DevOps Pipeline Concepts

**Pipeline**: An automated process that builds, tests, and deploys code.

**CI/CD Flow**:
```
Code Commit → Trigger Build → Run Tests → Deploy to Stage → Deploy to Production
```

**Key Concepts**:

- **Build Pipeline**: 
  - Triggered by code changes
  - Compiles code, runs unit tests, produces artifacts
  - Creates build artifacts

- **Release Pipeline**:
  - Takes artifacts from build
  - Deploys to different environments (dev, staging, production)
  - Runs integration/smoke tests

- **Trigger**: Event that starts a pipeline
  - Continuous Integration: Every code commit
  - Scheduled: Daily, weekly, etc.
  - Manual: User triggered

- **Agent**: Machine that executes pipeline tasks
  - Hosted agent: Microsoft-provided
  - Self-hosted: Your own infrastructure

- **Task**: Individual unit of work in a pipeline
  - Build code, run tests, deploy, etc.

- **Stage**: Collection of tasks executed sequentially or in parallel
  - Build stage, Test stage, Deploy stage

- **Environment**: Target deployment location
  - Development, Staging, Production

- **Artifact**: Output from build pipeline
  - Compiled code, packages, binaries

**Example Pipeline YAML**:
```yaml
trigger:
  - main

pool:
  vmImage: 'ubuntu-latest'

stages:
- stage: Build
  jobs:
  - job: BuildJob
    steps:
    - task: UseDotNet@2
      inputs:
        version: '6.0.x'
    - task: DotNetCoreCLI@2
      inputs:
        command: 'build'
    - task: DotNetCoreCLI@2
      inputs:
        command: 'test'
    - task: DotNetCoreCLI@2
      inputs:
        command: 'publish'

- stage: Deploy
  dependsOn: Build
  jobs:
  - deployment: DeployJob
    environment: 'Production'
    strategy:
      runOnce:
        deploy:
          steps:
          - task: AzureWebApp@1
            inputs:
              azureSubscription: 'Azure Connection'
              appName: 'MyWebApp'
```

---

## Module 2 - Git

### Why Git Was Invented

**Context**: Before Git (1991-2005), Linux kernel development used BitKeeper, but licensing issues arose.

**Linus Torvalds created Git (2005)** to solve:
- Need for fast, distributed version control
- Support for non-linear development (many branches)
- No reliance on a central server
- Strong data integrity and cryptographic verification

### Git Principles

**Distributed**: Every clone is a full backup of the repository and history.

**Staging Area (Index)**: 
- Intermediate stage between working directory and repository
- Allows selective commits with `git add`

**Commit**: 
- Snapshot of the project at a point in time
- Contains: files, metadata (author, timestamp), parent commit reference

**Push**: 
- Send commits from local repository to remote repository
- Updates the remote branch

**Pull**: 
- Fetch and merge changes from remote repository
- Equivalent to `git fetch` + `git merge`

**Merge**: 
- Combine changes from two branches
- Creates a merge commit with two parents

**Rebase**: 
- Reapply commits from one branch onto another
- Rewrites history, creates linear timeline
- Use case: Update feature branch with main branch changes

**Branch**: 
- Lightweight pointer to a specific commit
- Enable parallel development

### Internal Workings of Git

**Object Database**: Git stores 4 types of objects:

1. **Blob**: File content
   - Hash: SHA-1 of file content
   - Can be shared if identical content

2. **Tree**: Directory structure
   - Contains references to blobs (files) and trees (subdirectories)
   - Hash: SHA-1 of tree content

3. **Commit**: Snapshot of the project
   - Points to a tree (root directory)
   - References parent commit(s)
   - Contains metadata (author, timestamp, message)
   - Hash: SHA-1 of commit content

4. **Tag**: Reference to a commit
   - Annotated: full object with metadata
   - Lightweight: just a pointer

**Example Object Structure**:
```
Repository
├── .git/objects/
│   ├── ab/cd1234... (blob for main.py)
│   ├── ef/gh5678... (tree for src/)
│   ├── 12/34abcd... (commit: "Initial commit")
│   └── 56/78efgh... (commit: "Add feature X")
├── .git/refs/
│   ├── heads/main (points to commit 56/78efgh...)
│   └── heads/feature (points to commit 12/34abcd...)
└── .git/HEAD (points to heads/main)
```

**Merkle Tree**: Git uses cryptographic hashing
- Each commit's hash depends on its content AND parent's hash
- Changing history changes all subsequent hashes
- Detects tampering automatically

### Team Workflows with Git

**1. Centralized Workflow**:
- Single main branch
- All developers push to and pull from main
- Simple, but prone to conflicts
- Good for small teams

```
Developer A: make changes → push to main
Developer B: pull from main → make changes → push to main
```

**2. Feature Branch Workflow**:
- Main branch represents production-ready code
- Each feature gets its own branch
- Features merged back via pull requests
- Good for code review and quality control

```
main (production)
├── feature/user-auth
├── feature/payment-integration
└── bugfix/login-error
```

**3. Git Flow**:
- Multiple long-lived branches: main, develop
- Release branches for versions
- Hotfix branches for production bugs
- Good for projects with scheduled releases

```
main (releases)
└── develop (integration)
    ├── feature/new-feature
    ├── release/v1.2.0
    └── hotfix/critical-bug
```

**4. GitHub Flow** (also used with Azure DevOps):
- Single main branch (always deployable)
- Feature branches for changes
- Pull requests for review
- Automated tests before merge
- Good for continuous deployment

```
main (always deployable)
└── feature/user-profile (PR review → merge)
```

### Git Commands (Paper Exam Examples)

**Determine number of branches**:
```bash
git branch -a
git branch -r          # Remote branches only
git branch             # Local branches only
```

**Count commits**:
```bash
git rev-list --count HEAD              # Total commits to current branch
git rev-list --count main              # Commits to main branch
git log --oneline | wc -l              # Line count = number of commits
git rev-list --all --count             # All commits in repo
```

**Most recent commit author**:
```bash
git log -1 --format="%an"              # Author name of latest commit
git log -1 --format="%ae"              # Author email
git log -1 --format="%ai"              # Author date
```

**Identify merge type from diagram**:
- **Merge commit**: Two parents (merge from separate branches)
- **Fast-forward merge**: One parent (linear history, no divergence)
- **Rebase**: Re-parented commits, linear history

**Git object database example**:
```
Scenario: Two commits on main, one on feature branch

Commits:
- C1 (initial): tree T1
- C2 (on main): tree T2, parent C1
- C3 (on feature): tree T3, parent C1

Objects:
├── blob (file content)
├── tree T1 (files at C1)
├── tree T2 (files at C2)
├── tree T3 (files at C3)
├── commit C1 (tree T1, no parent)
├── commit C2 (tree T2, parent C1)
└── commit C3 (tree T3, parent C1)

References:
├── main → C2
└── feature → C3
```

### Praktische Git Voorbeelden met Branches (Voor Examen)

#### Voorbeeld 1: Complete Workflow met Feature Branch

```bash
# 1. Repository initialiseren en eerste commit maken
git init
git add .
git commit -m "Initial commit"

# 2. Nieuwe feature branch aanmaken
git branch feature/user-login
git checkout feature/user-login
# OF korter (branch aanmaken én switchen):
git checkout -b feature/user-login

# 3. Wijzigingen maken op feature branch
# (bestand bewerken)
git add login.cs
git commit -m "Add login functionality"
git commit -m "Add password validation"

# 4. Terug naar main en feature mergen
git checkout main
git merge feature/user-login

# 5. Feature branch verwijderen (cleanup)
git branch -d feature/user-login
```

**Hoe weet je hoeveel branches er zijn?**
```bash
# Alle lokale branches tonen:
git branch
# Output voorbeeld:
#   feature/user-login
# * main
#   bugfix/fix-crash

# Alle remote branches tonen:
git branch -r
# Output voorbeeld:
# origin/main
# origin/develop
# origin/feature/payment

# Alle branches (lokaal + remote):
git branch -a
# Output voorbeeld:
# * main
#   feature/user-login
#   remotes/origin/main
#   remotes/origin/develop

# ANTWOORD: Tel het aantal regels in de output
# In bovenstaand voorbeeld: 3 lokale branches
```

#### Voorbeeld 2: Parallel Development met Meerdere Branches

```bash
# Situatie: Main branch met 2 commits
git log --oneline
# a1b2c3d Second commit
# 9f8e7d6 Initial commit

# Developer A maakt feature branch
git checkout -b feature/shopping-cart
echo "ShoppingCart.cs" > ShoppingCart.cs
git add ShoppingCart.cs
git commit -m "Add shopping cart class"
git commit -m "Add cart item validation"

# Developer B maakt bugfix branch (vanaf main!)
git checkout main
git checkout -b bugfix/fix-null-pointer
echo "fix" >> Program.cs
git add Program.cs
git commit -m "Fix null pointer exception"

# Status bekijken:
git log --oneline --all --graph
# * 5d4c3b2 (bugfix/fix-null-pointer) Fix null pointer exception
# | * 2a1b0c9 (feature/shopping-cart) Add cart item validation
# | * 7e8f9g0 Add shopping cart class
# |/
# * a1b2c3d (main) Second commit
# * 9f8e7d6 Initial commit
```

**Hoeveel commits tel je?**
```bash
# Commits op huidige branch tellen:
git rev-list --count HEAD
# Output: 3 (als je op bugfix branch bent)

# Commits op specifieke branch tellen:
git rev-list --count main
# Output: 2

git rev-list --count feature/shopping-cart
# Output: 4 (Initial + Second + 2 shopping cart commits)

# ALLE commits in de repository tellen:
git rev-list --all --count
# Output: 5 (alle unieke commits)

# Alternatief met log:
git log --oneline main | wc -l
# Output: 2

# ANTWOORD: Tel commits vanaf de basis tot de branch tip
# Let op: Shared commits (zoals Initial commit) worden maar 1x geteld!
```

#### Voorbeeld 3: Merge Types Herkennen

**Fast-Forward Merge:**
```bash
# Situatie: feature branch is vooruit, main heeft geen nieuwe commits
git checkout -b feature/add-logger
git commit -m "Add logger class"
git commit -m "Add file logging"

git checkout main
git merge feature/add-logger
# Output: "Fast-forward"

# Resultaat in log:
git log --oneline --graph
# * 3c4d5e6 (HEAD -> main, feature/add-logger) Add file logging
# * 2b3c4d5 Add logger class
# * 1a2b3c4 Initial commit

# HERKENNING: Lineaire geschiedenis, geen merge commit!
```

**Merge Commit (3-way merge):**
```bash
# Situatie: Zowel main als feature hebben nieuwe commits
git checkout -b feature/api-integration
git commit -m "Add API client"

git checkout main
git commit -m "Update README"

git merge feature/api-integration
# Output: "Merge made by the 'recursive' strategy"

# Resultaat in log:
git log --oneline --graph
# *   7h8i9j0 (HEAD -> main) Merge branch 'feature/api-integration'
# |\
# | * 5f6g7h8 (feature/api-integration) Add API client
# * | 3d4e5f6 Update README
# |/
# * 1a2b3c4 Initial commit

# HERKENNING: Merge commit met 2 parents, diamant vorm in graph!
```

**Rebase (Lineaire Historie):**
```bash
# Situatie: Feature branch updaten met main changes
git checkout feature/new-feature
git rebase main

# Resultaat in log:
git log --oneline --graph
# * 9j0k1l2 (HEAD -> feature/new-feature) Feature commit 2
# * 8i9j0k1 Feature commit 1
# * 5f6g7h8 (main) Latest main commit
# * 1a2b3c4 Initial commit

# HERKENNING: Lineaire geschiedenis, commits zijn "verplaatst"
# Let op: Commit hashes zijn VERANDERD (rewrite history)!
```

#### Voorbeeld 4: Wie Deed de Laatste Commit?

```bash
# Meest recente commit info:
git log -1
# Output:
# commit a1b2c3d4e5f6
# Author: Jan Janssen <jan@example.com>
# Date:   Mon Jan 20 14:30:00 2026 +0100
#
#     Add user authentication

# Alleen naam van auteur:
git log -1 --format="%an"
# Output: Jan Janssen

# Alleen email:
git log -1 --format="%ae"
# Output: jan@example.com

# Compact formaat:
git log -1 --format="%an <%ae> - %s"
# Output: Jan Janssen <jan@example.com> - Add user authentication

# Laatste 3 commits met auteurs:
git log -3 --format="%h - %an: %s"
# Output:
# a1b2c3d - Jan Janssen: Add user authentication
# 9f8e7d6 - Marie Peeters: Fix bug in login
# 5d4c3b2 - Jan Janssen: Update dependencies

# ANTWOORD: Gebruik git log -1 --format="%an" voor auteursnaam
```

#### Voorbeeld 5: Git Object Database Tekenen

**Scenario**: Repository met 3 commits en 1 branch

```bash
# Commits maken:
git init
echo "Hello" > file1.txt
git add file1.txt
git commit -m "C1: Initial commit"

echo "World" > file2.txt
git add file2.txt
git commit -m "C2: Add file2"

git checkout -b feature
echo "Feature" > file3.txt
git add file3.txt
git commit -m "C3: Add feature"
```

**Object Database Tekening:**
```
┌─────────────────────────────────────────────────────────┐
│                    GIT OBJECT DATABASE                  │
├─────────────────────────────────────────────────────────┤
│                                                         │
│  BLOBS (file content):                                  │
│  ┌──────────────┐  ┌──────────────┐  ┌──────────────┐   │
│  │ blob: a1b2c3 │  │ blob: d4e5f6 │  │ blob: g7h8i9 │   │
│  │ "Hello"      │  │ "World"      │  │ "Feature"    │   │
│  └──────────────┘  └──────────────┘  └──────────────┘   │
│       file1.txt        file2.txt         file3.txt      │
│                                                         │
│  TREES (directory structure):                           │
│  ┌────────────────┐  ┌────────────────┐  ┌────────────┐ │
│  │ tree: T1       │  │ tree: T2       │  │ tree: T3   │ │
│  │ - file1.txt:   │  │ - file1.txt:   │  │ - file1.txt│ │
│  │   blob a1b2c3  │  │   blob a1b2c3  │  │ - file2.txt│ │
│  └────────────────┘  │ - file2.txt:   │  │ - file3.txt│ │
│         ▲            │   blob d4e5f6  │  │   blob g7h8│ │
│         │            └────────────────┘  └────────────┘ │
│         │                   ▲                   ▲       │
│         │                   │                   │       │
│  COMMITS:                   │                   │       │
│  ┌────────────────┐  ┌──────┴───────┐  ┌────────┴────┐  │
│  │ commit: C1     │◄─┤ commit: C2   │◄─┤ commit: C3  │  │
│  │ tree: T1       │  │ tree: T2     │  │ tree: T3    │  │
│  │ parent: none   │  │ parent: C1   │  │ parent: C1  │  │
│  │ author: Jan    │  │ author: Jan  │  │ author: Jan │  │
│  │ msg: "Initial" │  │ msg: "Add f2"│  │ msg: "Feat" │  │
│  └────────────────┘  └──────────────┘  └─────────────┘  │
│         ▲                   ▲                   ▲       │
│         │                   │                   │       │
│  REFERENCES (pointers):     │                   │       │
│         │                   │                   │       │
│    ┌────┴─────┐      ┌──────┴──────┐     ┌──────┴────┐  │
│    │ HEAD     │─────►│ refs/heads/ │     │refs/heads/│  │
│    │(symbolic)│      │    main     │     │  feature  │  │
│    └──────────┘      └─────────────┘     └───────────┘  │
│                                                         │
└─────────────────────────────────────────────────────────┘

TOELICHTING:
- C1 wijst naar tree T1 (bevat alleen file1.txt)
- C2 wijst naar tree T2 (bevat file1.txt + file2.txt)
- C2 heeft C1 als parent (pijl naar boven)
- C3 wijst naar tree T3 (bevat alle 3 files)
- C3 heeft C1 als parent (geforkt vanaf C1!)
- main branch wijst naar C2
- feature branch wijst naar C3
- HEAD wijst naar main (huidige branch)
```

#### Voorbeeld 6: Merge Conflicts Oplossen

```bash
# Situatie: Beide branches wijzigen hetzelfde bestand
git checkout -b feature/update-config
echo "FeatureConfig=true" >> config.txt
git add config.txt
git commit -m "Update config for feature"

git checkout main
echo "MainConfig=true" >> config.txt
git add config.txt
git commit -m "Update config on main"

# Proberen te mergen:
git merge feature/update-config
# Output: CONFLICT (content): Merge conflict in config.txt

# Conflict oplossen:
# 1. Open config.txt en zie conflict markers:
# <<<<<<< HEAD
# MainConfig=true
# =======
# FeatureConfig=true
# >>>>>>> feature/update-config

# 2. Bewerk bestand naar gewenste inhoud
# 3. Markeer als opgelost:
git add config.txt
git commit -m "Merge feature/update-config with conflict resolution"

# HERKENNING CONFLICT IN DIAGRAM:
# Als twee branches hetzelfde bestand wijzigen = mogelijk conflict!
```

#### Voorbeeld 7: Remote Repository Workflow

```bash
# Clone remote repository:
git clone https://github.com/user/repo.git
cd repo

# Zie remote branches:
git branch -r
# Output:
# origin/main
# origin/develop
# origin/feature/user-auth

# Nieuwe lokale branch vanaf remote:
git checkout -b feature/user-auth origin/feature/user-auth

# OF direct tracken:
git checkout --track origin/feature/user-auth

# Wijzigingen maken en pushen:
git add .
git commit -m "Update user authentication"
git push origin feature/user-auth

# Pull changes van remote:
git checkout main
git pull origin main
# Equivalent aan:
# git fetch origin
# git merge origin/main

# Alle remote branches ophalen:
git fetch --all

# Remote branch verwijderen:
git push origin --delete feature/old-feature
```

#### Voorbeeld 8: Geavanceerde Log Commands (Voor Examen)

```bash
# Grafische weergave van alle branches:
git log --oneline --graph --all --decorate
# Output:
# * 5d4c3b2 (HEAD -> main) Merge feature/shopping-cart
# |\
# | * 2a1b0c9 (feature/shopping-cart) Add cart validation
# | * 7e8f9g0 Add shopping cart
# |/
# * a1b2c3d Update README
# * 9f8e7d6 (tag: v1.0) Initial commit

# Commits tussen twee punten:
git log main..feature/shopping-cart
# Toont commits die in feature zitten maar NIET in main

# Commits op alle branches behalve main:
git log --all --not main

# Aantal commits per auteur:
git shortlog -sn
# Output:
# 15  Jan Janssen
#  8  Marie Peeters
#  3  Tom Smit

# Commits in laatste week:
git log --since="1 week ago" --oneline

# Files die gewijzigd zijn in commit:
git log --stat -1
# OF:
git show --name-only HEAD

# Zoeken in commit messages:
git log --grep="bug" --oneline
# Toont alle commits met "bug" in message
```

#### Belangrijke Exam Tips

1. **Branches tellen**: `git branch -a` → tel regels
2. **Commits tellen**: `git rev-list --count <branch>` 
3. **Laatste auteur**: `git log -1 --format="%an"`
4. **Merge type herkennen**: 
   - Fast-forward = lineair, geen merge commit
   - 3-way merge = merge commit met 2 parents
   - Rebase = lineair maar hashes gewijzigd
5. **Object database**: Altijd tonen: blobs → trees → commits → refs
6. **Graph tekenen**: `git log --graph --oneline --all`

---

## Module 2.5 - UML Diagrams (Unified Modeling Language)

### What is UML?

**UML (Unified Modeling Language)** is a standardized visual language for modeling software systems. It helps visualize the design of a system through diagrams.

**Purpose**: Communicate software architecture and design to developers, stakeholders, and documentation.

**Most Common Type**: **Class Diagrams** - show classes, their attributes, methods, and relationships.

---

### Basic Class Diagram Structure

```
┌─────────────────────────┐
│      ClassName          │  ← Class Name
├─────────────────────────┤
│ - privateField: type    │  ← Attributes/Fields
│ + publicField: type     │
│ # protectedField: type  │
├─────────────────────────┤
│ + publicMethod(): type  │  ← Methods/Operations
│ - privateMethod()       │
│ # protectedMethod()     │
└─────────────────────────┘
```

**Visibility Markers**:
- `+` = **public** (accessible from anywhere)
- `-` = **private** (only accessible within the class)
- `#` = **protected** (accessible in class and subclasses)
- `~` = **package/internal** (accessible within same package/assembly)

**Example**:
```
┌─────────────────────────┐
│      BankAccount        │
├─────────────────────────┤
│ - balance: decimal      │  ← private field
│ - accountNumber: string │
├─────────────────────────┤
│ + Deposit(amount)       │  ← public method
│ + Withdraw(amount)      │
│ + GetBalance(): decimal │
│ - ValidateAmount()      │  ← private method
└─────────────────────────┘
```

---

### UML Relationships and Arrows

#### 1. **Inheritance (Generalization)** - "IS-A" Relationship

**Symbol**: `△` (hollow triangle pointing to parent)

```
┌────────────┐
│   Animal   │
└────────────┘
      △
      │
      │
┌─────┴──────┐
│    Dog     │
└────────────┘
```

**Meaning**: Dog **is an** Animal (inheritance/extends)

**C# Code**:
```csharp
public class Animal { }
public class Dog : Animal { }
```

---

#### 2. **Realization/Implementation** - Interface Implementation

**Symbol**: `△` with dashed line (hollow triangle with dashed line)

```
┌──────────────────┐
│ <<interface>>    │
│   IFlyable       │
└──────────────────┘
      △ ┆ ┆ ┆ (dashed line)
      ┆
┌─────┴──────┐
│    Bird    │
└────────────┘
```

**Meaning**: Bird **implements** IFlyable interface

**C# Code**:
```csharp
public interface IFlyable { }
public class Bird : IFlyable { }
```

---

#### 3. **Association** - "HAS-A" or "USES" Relationship

**Symbol**: `────>` (solid line with arrow)

```
┌────────────┐           ┌────────────┐
│  Student   │────────> │  Course    │
└────────────┘           └────────────┘
```

**Meaning**: Student **has a reference to** Course (uses)

**C# Code**:
```csharp
public class Student
{
    public Course CurrentCourse { get; set; }
}
```

**Bidirectional Association** (both know about each other):
```
┌────────────┐           ┌────────────┐
│  Student   │◄────────> │  Course    │
└────────────┘           └────────────┘
```

---

#### 4. **Aggregation** - "HAS-A" (Weak Ownership)

**Symbol**: `◇────>` (hollow diamond at container side)

```
┌────────────┐ ◇        ┌────────────┐
│ Department │────────> │  Employee  │
└────────────┘           └────────────┘
```

**Meaning**: Department **has** Employees, but Employees can exist independently

**Key**: Objects can exist separately (weak relationship)

**C# Code**:
```csharp
public class Department
{
    public List<Employee> Employees { get; set; }
}

public class Employee { } // Can exist without Department
```

---

#### 5. **Composition** - "HAS-A" (Strong Ownership)

**Symbol**: `◆────>` (filled/solid diamond at container side)

```
┌────────────┐ ◆        ┌────────────┐
│   House    │────────> │    Room    │
└────────────┘           └────────────┘
```

**Meaning**: House **owns** Rooms; Rooms cannot exist without House

**Key**: Lifetime dependency - if House is destroyed, Rooms are destroyed

**C# Code**:
```csharp
public class House
{
    private List<Room> _rooms;
    
    public House()
    {
        _rooms = new List<Room>(); // Creates rooms
    }
}

public class Room { } // Cannot exist without House
```

---

#### 6. **Dependency** - "USES" (Temporary)

**Symbol**: `┆ ┆ ┆>` (dashed arrow)

```
┌────────────┐  ┆ ┆ ┆   ┌────────────┐
│   Service  │ ┆ ┆ ┆ > │  Logger    │
└────────────┘           └────────────┘
```

**Meaning**: Service **temporarily uses** Logger (parameter, local variable, return type)

**C# Code**:
```csharp
public class Service
{
    public void DoWork(Logger logger)  // Dependency via parameter
    {
        logger.Log("Working...");
    }
}
```

---

### Multiplicity (Cardinality)

Shows how many instances can be associated.

**Common Notations**:
- `1` = exactly one
- `0..1` = zero or one (optional)
- `*` or `0..*` = zero or more
- `1..*` = one or more
- `n` = exactly n

**Examples**:
```
┌────────────┐  1      *  ┌────────────┐
│  Customer  │───────────>│   Order    │
└────────────┘             └────────────┘
```
**Meaning**: 1 Customer can have many (*) Orders

```
┌────────────┐  1      1  ┌────────────┐
│   Person   │───────────>│  Passport  │
└────────────┘             └────────────┘
```
**Meaning**: 1 Person has exactly 1 Passport

```
┌────────────┐  *      *  ┌────────────┐
│  Student   │───────────>│  Course    │
└────────────┘             └────────────┘
```
**Meaning**: Many Students can enroll in many Courses (many-to-many)

---

### Quick Reference Chart

| Relationship | Arrow | Filled/Hollow | Line Type | Meaning | Example |
|--------------|-------|---------------|-----------|---------|---------|
| **Inheritance** | `△` | Hollow | Solid | IS-A | Dog → Animal |
| **Implementation** | `△` | Hollow | Dashed | Implements | Bird ┆→ IFlyable |
| **Association** | `→` | Arrow | Solid | Uses/Has | Student → Course |
| **Aggregation** | `◇→` | Hollow Diamond | Solid | Weak Has | Dept ◇→ Employee |
| **Composition** | `◆→` | Filled Diamond | Solid | Strong Has | House ◆→ Room |
| **Dependency** | `┆→` | Arrow | Dashed | Temporary Use | Service ┆→ Logger |

---

### Complete Example: Library System

```
                    ┌──────────────────┐
                    │  <<interface>>   │
                    │   IBorrowable    │
                    ├──────────────────┤
                    │ + Borrow()       │
                    │ + Return()       │
                    └──────────────────┘
                           △ ┆ ┆ ┆
                           ┆ ┆ ┆
        ┌──────────────────┴───┴──────────────────┐
        │                                          │
┌───────┴────────┐                        ┌────────┴───────┐
│     Book       │                        │      DVD       │
├────────────────┤                        ├────────────────┤
│ - title: string│                        │ - title: string│
│ - isbn: string │                        │ - duration: int│
├────────────────┤                        ├────────────────┤
│ + Borrow()     │                        │ + Borrow()     │
│ + Return()     │                        │ + Return()     │
└────────────────┘                        └────────────────┘
        △                                          △
        │                                          │
        │                                          │
┌───────┴────────┐                        ┌────────┴───────┐
│  EBook         │                        │  BluRay        │
└────────────────┘                        └────────────────┘

┌────────────────┐ ◆        1..*  ┌────────────────┐
│    Library     │───────────────>│   Shelf        │
└────────────────┘                 └────────────────┘
        │ ◇                                 │ ◇
        │                                   │
        │ 1                           *    │ *
        │                                   │
        └────────────────┐  ┌───────────────┘
                         │  │
                    ┌────▼──▼─────┐
                    │     Book     │
                    └──────────────┘
                         △
                         │ ┆ ┆ ┆
                    ┌────┴──────┐
                    │  Member   │
                    │ (borrows) │
                    └───────────┘
```

**Relationships Explained**:
1. **Implementation** (┆→): Book and DVD implement IBorrowable interface
2. **Inheritance** (△): EBook extends Book, BluRay extends DVD
3. **Composition** (◆→): Library strongly owns Shelves (1 to many)
4. **Aggregation** (◇→): Library has Books, Shelf has Books (weak - books can exist independently)
5. **Dependency** (┆→): Member depends on Book when borrowing

---

### Abstract Classes vs Interfaces in UML

**Abstract Class**:
```
┌────────────────────┐
│  <<abstract>>      │
│   Shape            │
├────────────────────┤
│ # color: string    │
├────────────────────┤
│ + Draw()           │  ← can have implementation
│ + {abstract} Area()│  ← abstract method
└────────────────────┘
```

**Interface**:
```
┌────────────────────┐
│  <<interface>>     │
│   IDrawable        │
├────────────────────┤
│ + Draw()           │  ← only method signatures
└────────────────────┘
```

---

### Notes and Stereotypes

**Stereotypes** are keywords in `<< >>` that classify elements:
- `<<interface>>` - Interface
- `<<abstract>>` - Abstract class
- `<<enum>>` - Enumeration
- `<<singleton>>` - Singleton pattern
- `<<utility>>` - Utility/static class

**Example**:
```
┌────────────────────┐
│  <<singleton>>     │
│   Logger           │
├────────────────────┤
│ - instance: Logger │
├────────────────────┤
│ + GetInstance()    │
│ + Log(message)     │
└────────────────────┘
```

---

### Common Exam Questions on UML

**1. "What type of relationship is shown?"**
- Look at the arrow and line type
- Check if it's solid/dashed and what's at the end

**2. "Draw the UML for this code"**
```csharp
public interface IPayment
{
    void Process();
}

public class CreditCard : IPayment
{
    private Bank _bank;
    
    public void Process() { }
}
```

**Answer**:
```
┌────────────────┐
│ <<interface>>  │
│   IPayment     │
├────────────────┤
│ + Process()    │
└────────────────┘
      △ ┆ ┆ ┆
      ┆ ┆ ┆
┌─────┴──────┐           ┌────────────┐
│ CreditCard │◆─────────>│    Bank    │
├────────────┤            └────────────┘
│ - bank     │
├────────────┤
│ + Process()│
└────────────┘
```

**3. "Explain the difference between aggregation and composition"**
- **Aggregation** (◇): Weak ownership, child can exist independently
  - Example: Department has Employees (employees can exist without department)
- **Composition** (◆): Strong ownership, child cannot exist without parent
  - Example: House has Rooms (rooms destroyed when house is destroyed)

---

### UML Best Practices for Exams

1. **Always show visibility** (+, -, #)
2. **Include multiplicities** on associations (1, *, 0..1, etc.)
3. **Use correct arrow types** - solid vs dashed, filled vs hollow
4. **Label interfaces** with `<<interface>>`
5. **Show inheritance** with hollow triangle
6. **Composition vs Aggregation** - think about lifetime dependency
7. **Keep diagrams simple** - don't show every detail unless asked

---

## Module 3 - Design Patterns

### Classic Design Patterns (Studied in Class)

#### 1. Strategy Pattern

**Definition**: Encapsulate a family of algorithms, making them interchangeable.

**Problem**: Multiple algorithms for a task; need to switch between them at runtime.

**UML Class Diagram**:
```
┌─────────────────────┐
│     Context         │
├─────────────────────┤
│ - strategy: Strategy│
├─────────────────────┤
│ + doWork()          │
└─────────────────────┘
         │ uses
         ▼
┌─────────────────────┐
│ <<interface>>       │
│    Strategy         │
├─────────────────────┤
│ + execute()         │
└─────────────────────┘
    △         △
    │         │
    │    ┌────┴──────────┐
    │    │               │
┌───┴────────┐  ┌─────────────┐
│ ConcreteA   │  │ ConcreteB   │
├─────────────┤  ├─────────────┤
│ + execute() │  │ + execute() │
└─────────────┘  └─────────────┘
```

**C# Example**:
```csharp
// Strategy Interface
public interface IPaymentStrategy
{
    void Pay(decimal amount);
}

// Concrete Strategies
public class CreditCardPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paying ${amount} with credit card");
    }
}

public class PayPalPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paying ${amount} with PayPal");
    }
}

// Context
public class ShoppingCart
{
    private IPaymentStrategy _paymentStrategy;

    public void SetPaymentStrategy(IPaymentStrategy strategy)
    {
        _paymentStrategy = strategy;
    }

    public void Checkout(decimal total)
    {
        _paymentStrategy.Pay(total);
    }
}

// Usage
var cart = new ShoppingCart();
cart.SetPaymentStrategy(new CreditCardPayment());
cart.Checkout(100);  // Output: Paying $100 with credit card

cart.SetPaymentStrategy(new PayPalPayment());
cart.Checkout(50);   // Output: Paying $50 with PayPal
```

**Benefits**: 
- Easy to add new algorithms without modifying context
- Runtime algorithm selection
- Follows Open/Closed Principle

---

#### 2. Observer Pattern

**Definition**: Define a one-to-many dependency where when one object changes state, all dependents are notified automatically.

**Problem**: Multiple objects need to react to state changes in another object.

**UML Class Diagram**:
```
┌──────────────────┐
│    Subject       │
├──────────────────┤
│ - observers: []  │
├──────────────────┤
│ + attach()       │
│ + detach()       │
│ + notify()       │
└──────────────────┘
         │
         │ notifies
         ▼
┌──────────────────┐
│ <<interface>>    │
│    Observer      │
├──────────────────┤
│ + update()       │
└──────────────────┘
    △         △
    │         │
┌───┴────────┐  ┌──────────────┐
│ ConcreteA  │  │ ConcreteB    │
├────────────┤  ├──────────────┤
│ + update() │  │ + update()   │
└────────────┘  └──────────────┘
```

**C# Example**:
```csharp
public interface IObserver
{
    void Update(string message);
}

public class Subject
{
    private List<IObserver> _observers = new();

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify(string message)
    {
        foreach (var observer in _observers)
        {
            observer.Update(message);
        }
    }
}

public class EmailObserver : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"Email sent: {message}");
    }
}

public class SMSObserver : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"SMS sent: {message}");
    }
}

// Usage
var subject = new Subject();
subject.Attach(new EmailObserver());
subject.Attach(new SMSObserver());
subject.Notify("Alert!");
// Output:
// Email sent: Alert!
// SMS sent: Alert!
```

**Benefits**:
- Loose coupling between subject and observers
- Dynamic observer subscription
- Supports broadcast communication

---

#### 3. Factory Pattern

**Definition**: Create objects without specifying their exact classes.

**Problem**: Object creation is complex or needs flexibility in which type to instantiate.

**UML Class Diagram**:
```
┌─────────────────────┐
│     Factory         │
├─────────────────────┤
│ + create(): Product │
└─────────────────────┘
         │ creates
         ▼
┌─────────────────────┐
│ <<interface>>       │
│    Product         │
├─────────────────────┤
│ + operation()       │
└─────────────────────┘
    △         △
    │         │
┌───┴────────┐  ┌──────────────┐
│ ConcreteA  │  │ ConcreteB    │
├────────────┤  ├──────────────┤
│ operation()│  │ operation()  │
└────────────┘  └──────────────┘
```

**C# Example**:
```csharp
public interface ITransport
{
    void Deliver();
}

public class Truck : ITransport
{
    public void Deliver()
    {
        Console.WriteLine("Delivering by truck");
    }
}

public class Ship : ITransport
{
    public void Deliver()
    {
        Console.WriteLine("Delivering by ship");
    }
}

public class TransportFactory
{
    public ITransport CreateTransport(string type)
    {
        return type.ToLower() switch
        {
            "truck" => new Truck(),
            "ship" => new Ship(),
            _ => throw new ArgumentException("Unknown transport")
        };
    }
}

// Usage
var factory = new TransportFactory();
var truck = factory.CreateTransport("truck");
truck.Deliver();  // Output: Delivering by truck

var ship = factory.CreateTransport("ship");
ship.Deliver();   // Output: Delivering by ship
```

**Benefits**:
- Encapsulates object creation
- Easy to add new product types
- Reduces coupling to concrete classes

---

#### 4. State Pattern

**Definition**: Allow an object to alter its behavior when its internal state changes.

**Problem**: Object behavior changes drastically based on state; many conditional statements.

**UML Class Diagram**:
```
┌──────────────────┐
│    Context       │
├──────────────────┤
│ - state: State   │
├──────────────────┤
│ + request()      │
│ + setState()     │
└──────────────────┘
         │
         ▼
┌──────────────────┐
│ <<interface>>    │
│     State        │
├──────────────────┤
│ + handle()       │
└──────────────────┘
    △         △
    │         │
┌───┴────────┐  ┌──────────────┐
│ ConcreteA  │  │ ConcreteB    │
├────────────┤  ├──────────────┤
│ + handle() │  │ + handle()   │
└────────────┘  └──────────────┘
```

**C# Example**:
```csharp
public interface IState
{
    void Handle(Context context);
}

public class StartState : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("Starting...");
        context.State = new RunningState();
    }
}

public class RunningState : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("Running...");
        context.State = new StoppedState();
    }
}

public class StoppedState : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("Stopped");
        context.State = new StartState();
    }
}

public class Context
{
    public IState State { get; set; }

    public Context()
    {
        State = new StartState();
    }

    public void Request()
    {
        State.Handle(this);
    }
}

// Usage
var context = new Context();
context.Request();  // Output: Starting...
context.Request();  // Output: Running...
context.Request();  // Output: Stopped
```

**Benefits**:
- Eliminates large conditional statements
- State-specific behavior encapsulated in separate classes
- Easy to add new states

---

### Self-Studied Design Patterns

#### 5. Decorator Pattern

**Definition**: Attach additional responsibilities to an object dynamically, keeping the same interface.

**Problem**: Need to add behavior to objects without modifying their class and without subclass explosion.

**UML Class Diagram**:
```
┌──────────────────┐
│ <<interface>>    │
│   Component      │
├──────────────────┤
│ + operation()    │
└──────────────────┘
    △         △
    │         │
    │    ┌────────────────────┐
    │    │   Decorator        │
    │    ├────────────────────┤
    │    │ - component        │
    │    ├────────────────────┤
    │    │ + operation()      │
    │    └────────────────────┘
    │              △
    │              │
┌───┴──────┐  ┌─────┴──────────┐
│ Concrete │  │ ConcreteDecorator
│Component │  ├────────────────┤
└──────────┘  │ + operation()  │
              └────────────────┘
```

**C# Example**:
```csharp
public interface IComponent
{
    string GetDescription();
    decimal GetCost();
}

public class SimpleCoffee : IComponent
{
    public string GetDescription() => "Simple Coffee";
    public decimal GetCost() => 2.00m;
}

public abstract class CoffeeDecorator : IComponent
{
    protected IComponent _component;

    public CoffeeDecorator(IComponent component)
    {
        _component = component;
    }

    public virtual string GetDescription() => _component.GetDescription();
    public virtual decimal GetCost() => _component.GetCost();
}

public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(IComponent component) : base(component) { }

    public override string GetDescription()
    {
        return _component.GetDescription() + ", with milk";
    }

    public override decimal GetCost()
    {
        return _component.GetCost() + 0.50m;
    }
}

public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(IComponent component) : base(component) { }

    public override string GetDescription()
    {
        return _component.GetDescription() + ", with sugar";
    }

    public override decimal GetCost()
    {
        return _component.GetCost() + 0.25m;
    }
}

// Usage
IComponent coffee = new SimpleCoffee();
coffee = new MilkDecorator(coffee);
coffee = new SugarDecorator(coffee);
Console.WriteLine(coffee.GetDescription());  // Output: Simple Coffee, with milk, with sugar
Console.WriteLine(coffee.GetCost());         // Output: 2.75
```

**Benefits**:
- More flexible than inheritance
- Easy to combine multiple decorators
- Follows Single Responsibility Principle

---

#### 6. Singleton Pattern

**Definition**: Ensure a class has only one instance and provide a global point of access to it.

**Problem**: Some classes should have exactly one instance (database connection, logger, configuration).

**UML Class Diagram**:
```
┌──────────────────────────────┐
│   Singleton                  │
├──────────────────────────────┤
│ - instance: Singleton        │
│ - Singleton()                │
├──────────────────────────────┤
│ + getInstance(): Singleton   │
└──────────────────────────────┘
```

**C# Example (Thread-Safe)**:
```csharp
public class Logger
{
    private static Logger _instance;
    private static readonly object _lock = new();

    private Logger() { }

    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
            }
        }
        return _instance;
    }

    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {DateTime.Now}: {message}");
    }
}

// Modern C# approach (lazy initialization)
public class LoggerModern
{
    private static readonly Lazy<LoggerModern> _instance 
        = new(() => new LoggerModern());

    private LoggerModern() { }

    public static LoggerModern Instance => _instance.Value;

    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {DateTime.Now}: {message}");
    }
}

// Usage
Logger.GetInstance().Log("Application started");
Logger.GetInstance().Log("Processing data");

// Or modern
LoggerModern.Instance.Log("Modern approach");
```

**Benefits**:
- Controlled global access
- Ensures single instance
- Lazy initialization possible

**Drawbacks**:
- Can make testing difficult
- Hidden dependencies

---

#### 7. Command Pattern

**Definition**: Encapsulate a request as an object, allowing parameterization of clients with different requests, queuing of requests, and logging of requests.

**Problem**: Need to decouple objects that invoke operations from objects that perform them; support undo/redo.

**UML Class Diagram**:
```
┌──────────────────┐
│   Invoker        │
├──────────────────┤
│ - command        │
├──────────────────┤
│ + execute()      │
└──────────────────┘
         │ uses
         ▼
┌──────────────────┐
│ <<interface>>    │
│    Command       │
├──────────────────┤
│ + execute()      │
│ + undo()         │
└──────────────────┘
    △         △
    │         │
┌───┴────────┐  ┌──────────────┐
│ ConcreteA  │  │ ConcreteB    │
├────────────┤  ├──────────────┤
│ - receiver  │  │ - receiver   │
│ + execute() │  │ + execute()  │
│ + undo()    │  │ + undo()     │
└────────────┘  └──────────────┘
         △         △
         │         │
         └─────┬───┘
               │ controls
               ▼
         ┌──────────────┐
         │   Receiver   │
         └──────────────┘
```

**C# Example**:
```csharp
public interface ICommand
{
    void Execute();
    void Undo();
}

public class TextDocument
{
    public string Content { get; set; } = "";

    public void AddText(string text)
    {
        Content += text;
    }

    public void RemoveLastCharacter()
    {
        if (Content.Length > 0)
            Content = Content.Substring(0, Content.Length - 1);
    }
}

public class AddTextCommand : ICommand
{
    private readonly TextDocument _document;
    private readonly string _text;

    public AddTextCommand(TextDocument document, string text)
    {
        _document = document;
        _text = text;
    }

    public void Execute()
    {
        _document.AddText(_text);
    }

    public void Undo()
    {
        for (int i = 0; i < _text.Length; i++)
        {
            _document.RemoveLastCharacter();
        }
    }
}

public class TextEditor
{
    private Stack<ICommand> _history = new();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _history.Push(command);
    }

    public void Undo()
    {
        if (_history.Count > 0)
        {
            var command = _history.Pop();
            command.Undo();
        }
    }
}

// Usage
var document = new TextDocument();
var editor = new TextEditor();

editor.ExecuteCommand(new AddTextCommand(document, "Hello "));
editor.ExecuteCommand(new AddTextCommand(document, "World"));
Console.WriteLine(document.Content);  // Output: Hello World

editor.Undo();
Console.WriteLine(document.Content);  // Output: Hello 

editor.Undo();
Console.WriteLine(document.Content);  // Output: (empty)
```

**Benefits**:
- Decouples command senders from receivers
- Enables queuing and scheduling of commands
- Supports undo/redo functionality
- Enables macro recording

---

#### 8. Template Method Pattern

**Definition**: Define the skeleton of an algorithm in a base class, letting subclasses override specific steps.

**Problem**: Multiple classes with similar algorithms; only certain steps differ.

**UML Class Diagram**:
```
┌────────────────────────┐
│  AbstractClass         │
├────────────────────────┤
│ # templateMethod()     │
│ # primitiveOp1()       │
│ # primitiveOp2()       │
└────────────────────────┘
    △         △
    │         │
┌───┴────────┐  ┌─────────────────┐
│ ConcreteA  │  │ ConcreteB       │
├────────────┤  ├─────────────────┤
│ primitiveOp1│  │ # primitiveOp1()│
│ primitiveOp2│  │ # primitiveOp2()│
└────────────┘  └─────────────────┘
```

**C# Example**:
```csharp
public abstract class DataProcessor
{
    // Template method - defines algorithm skeleton
    public void Process()
    {
        ReadData();
        ValidateData();
        TransformData();
        SaveData();
    }

    protected abstract void ReadData();
    protected abstract void ValidateData();
    protected abstract void TransformData();
    protected abstract void SaveData();
}

public class CSVProcessor : DataProcessor
{
    protected override void ReadData()
    {
        Console.WriteLine("Reading CSV file...");
    }

    protected override void ValidateData()
    {
        Console.WriteLine("Validating CSV data...");
    }

    protected override void TransformData()
    {
        Console.WriteLine("Transforming CSV to objects...");
    }

    protected override void SaveData()
    {
        Console.WriteLine("Saving to database...");
    }
}

public class JSONProcessor : DataProcessor
{
    protected override void ReadData()
    {
        Console.WriteLine("Reading JSON file...");
    }

    protected override void ValidateData()
    {
        Console.WriteLine("Validating JSON structure...");
    }

    protected override void TransformData()
    {
        Console.WriteLine("Parsing JSON to objects...");
    }

    protected override void SaveData()
    {
        Console.WriteLine("Saving to database...");
    }
}

// Usage
DataProcessor csvProcessor = new CSVProcessor();
csvProcessor.Process();
// Output:
// Reading CSV file...
// Validating CSV data...
// Transforming CSV to objects...
// Saving to database...

DataProcessor jsonProcessor = new JSONProcessor();
jsonProcessor.Process();
```

**Benefits**:
- Reduces code duplication
- Promotes code reuse
- Standardizes algorithm structure
- Follows DRY principle

---

### Pattern Recognition and Selection

**How to recognize a pattern from code**:
1. Look for class relationships and interfaces
2. Identify the problem being solved
3. Check for specific characteristics:
   - Strategy: Multiple algorithms, swappable at runtime
   - Observer: One-to-many notification
   - Factory: Object creation encapsulation
   - State: Behavior changes with state
   - Decorator: Adding behavior without modification
   - Singleton: Single instance requirement
   - Command: Request as object, undo/redo
   - Template Method: Algorithm skeleton with variable steps

**Pattern selection guide**:

| Problem | Pattern | Why |
|---------|---------|-----|
| Multiple algorithms, switch runtime | Strategy | Runtime flexibility |
| Object state changes behavior | State | Clear state encapsulation |
| Complex object creation | Factory | Encapsulates creation logic |
| One object, many dependents | Observer | Loose coupling notification |
| Add behavior without modification | Decorator | Maintains interface, extends functionality |
| Single instance needed | Singleton | Ensures one instance globally |
| Request queuing, undo/redo | Command | Encapsulates request as object |
| Similar algorithm, different steps | Template Method | Code reuse, variable steps |

---

## Module 4 - SOLID Principles

### SOLID Principles Overview

**SOLID** is an acronym for five design principles that promote maintainable, scalable, and robust object-oriented code.

#### 1. Single Responsibility Principle (SRP)

**Definition**: A class should have only one reason to change.

**Meaning**: Each class should have a single, well-defined responsibility.

**Violation Example**:
```csharp
// WRONG - Multiple responsibilities
public class User
{
    public string Name { get; set; }
    public string Email { get; set; }

    public void SaveToDatabase()  // Database responsibility
    {
        // Save to DB
    }

    public void SendEmail()       // Email responsibility
    {
        // Send email
    }

    public void GenerateReport()  // Reporting responsibility
    {
        // Generate report
    }
}
```

**Corrected Example**:
```csharp
// CORRECT - Single responsibility each
public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
}

public class UserRepository
{
    public void SaveToDatabase(User user)
    {
        // Save to DB
    }
}

public class EmailService
{
    public void SendEmail(User user)
    {
        // Send email
    }
}

public class ReportGenerator
{
    public void GenerateReport(User user)
    {
        // Generate report
    }
}
```

**Benefits**: Easier maintenance, testing, and changes affect only one class.

---

#### 2. Open/Closed Principle (OCP)

**Definition**: Software entities should be open for extension but closed for modification.

**Meaning**: You should be able to add new functionality without changing existing code.

**Violation Example**:
```csharp
// WRONG - Must modify class for new shape
public class AreaCalculator
{
    public decimal CalculateArea(object shape)
    {
        if (shape is Circle circle)
            return 3.14m * circle.Radius * circle.Radius;
        
        if (shape is Rectangle rectangle)
            return rectangle.Width * rectangle.Height;
        
        // Must modify this method for each new shape!
        throw new ArgumentException("Unknown shape");
    }
}
```

**Corrected Example**:
```csharp
// CORRECT - Extend without modification
public interface IShape
{
    decimal CalculateArea();
}

public class Circle : IShape
{
    public decimal Radius { get; set; }
    
    public decimal CalculateArea()
    {
        return 3.14m * Radius * Radius;
    }
}

public class Rectangle : IShape
{
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    
    public decimal CalculateArea()
    {
        return Width * Height;
    }
}

public class AreaCalculator
{
    public decimal CalculateArea(IShape shape)
    {
        return shape.CalculateArea();  // Works for all shapes!
    }
}

// Adding new shape doesn't require modifying AreaCalculator
public class Triangle : IShape
{
    public decimal Base { get; set; }
    public decimal Height { get; set; }
    
    public decimal CalculateArea()
    {
        return 0.5m * Base * Height;
    }
}
```

**Benefits**: Less risk of breaking existing code, easier to extend functionality.

---

#### 3. Liskov Substitution Principle (LSP)

**Definition**: Derived classes must be substitutable for their base classes.

**Meaning**: A subclass should not break the contract of its parent class.

**Violation Example**:
```csharp
// WRONG - Penguin cannot fly
public class Bird
{
    public virtual void Fly()
    {
        Console.WriteLine("Flying");
    }
}

public class Eagle : Bird
{
    public override void Fly()
    {
        Console.WriteLine("Eagle flying high");
    }
}

public class Penguin : Bird
{
    public override void Fly()
    {
        throw new NotImplementedException("Penguins cannot fly!");
    }
}

// This breaks LSP
public class AirPlane
{
    public void TakeBird(Bird bird)
    {
        bird.Fly();  // Crashes if it's a Penguin!
    }
}
```

**Corrected Example**:
```csharp
// CORRECT - Proper hierarchy
public abstract class Bird { }

public interface IFlyable
{
    void Fly();
}

public interface ISwimmable
{
    void Swim();
}

public class Eagle : Bird, IFlyable
{
    public void Fly()
    {
        Console.WriteLine("Eagle flying high");
    }
}

public class Penguin : Bird, ISwimmable
{
    public void Swim()
    {
        Console.WriteLine("Penguin swimming");
    }
}

public class AirPlane
{
    public void TakeBird(IFlyable flyable)
    {
        flyable.Fly();  // Safe - only flyable things
    }
}
```

**Benefits**: Prevents unexpected errors from incorrect substitutions.

---

#### 4. Interface Segregation Principle (ISP)

**Definition**: Clients should not be forced to depend on interfaces they do not use.

**Meaning**: Create smaller, more specific interfaces rather than large general ones.

**Violation Example**:
```csharp
// WRONG - Large interface with unrelated methods
public interface IWorker
{
    void Work();
    void Eat();
    void Sleep();
}

public class Robot : IWorker
{
    public void Work()
    {
        Console.WriteLine("Robot working");
    }

    public void Eat()
    {
        throw new NotImplementedException("Robots don't eat");
    }

    public void Sleep()
    {
        throw new NotImplementedException("Robots don't sleep");
    }
}
```

**Corrected Example**:
```csharp
// CORRECT - Segregated interfaces
public interface IWorkable
{
    void Work();
}

public interface IEatable
{
    void Eat();
}

public interface ISleepable
{
    void Sleep();
}

public class Human : IWorkable, IEatable, ISleepable
{
    public void Work() => Console.WriteLine("Human working");
    public void Eat() => Console.WriteLine("Human eating");
    public void Sleep() => Console.WriteLine("Human sleeping");
}

public class Robot : IWorkable
{
    public void Work() => Console.WriteLine("Robot working");
    // No need to implement Eat and Sleep
}
```

**Benefits**: Classes only implement what they need, easier to maintain and test.

---

#### 5. Dependency Inversion Principle (DIP)

**Definition**: Depend on abstractions, not on concrete implementations.

**Meaning**: High-level modules should not depend on low-level modules; both should depend on abstractions.

**Violation Example**:
```csharp
// WRONG - Depends on concrete class
public class MySQLDatabase
{
    public void Save(string data)
    {
        Console.WriteLine("Saving to MySQL: " + data);
    }
}

public class UserService
{
    private MySQLDatabase _database = new();  // Hard dependency!

    public void SaveUser(string user)
    {
        _database.Save(user);
    }
}

// Can't test with different database, can't switch databases
```

**Corrected Example**:
```csharp
// CORRECT - Depends on abstraction
public interface IDatabase
{
    void Save(string data);
}

public class MySQLDatabase : IDatabase
{
    public void Save(string data)
    {
        Console.WriteLine("Saving to MySQL: " + data);
    }
}

public class MongoDatabase : IDatabase
{
    public void Save(string data)
    {
        Console.WriteLine("Saving to MongoDB: " + data);
    }
}

public class UserService
{
    private readonly IDatabase _database;

    // Dependency injection - depends on abstraction
    public UserService(IDatabase database)
    {
        _database = database;
    }

    public void SaveUser(string user)
    {
        _database.Save(user);
    }
}

// Usage
IDatabase database = new MySQLDatabase();
var userService = new UserService(database);
userService.SaveUser("John");

// Easy to switch
database = new MongoDatabase();
userService = new UserService(database);
userService.SaveUser("Jane");
```

**Benefits**: Loose coupling, easy testing, flexible implementation switching.

---

### SOLID Violations in Code - Analysis Examples

**Example Code Review**:
```csharp
public class OrderProcessor
{
    public void ProcessOrder(Order order)
    {
        // Validate order - SRP violation
        if (order.Items.Count == 0)
            throw new Exception("Order empty");
        
        // Send email - SRP violation
        EmailService.Send(order.CustomerId, "Order received");
        
        // Calculate tax - SRP violation
        decimal tax = order.Total * 0.15m;
        
        // Save to database - SRP violation
        Database.SaveOrder(order);
        
        // Print receipt - SRP violation
        Console.WriteLine($"Order total: {order.Total + tax}");
    }
}
```

**Violations Identified**:
1. **SRP**: Multiple responsibilities (validation, email, tax, saving, printing)
2. **OCP**: Adding payment methods requires modification
3. **DIP**: Direct dependency on EmailService and Database

**Refactored Solution**:
```csharp
// Segregate responsibilities
public interface IOrderValidator
{
    void Validate(Order order);
}

public interface INotificationService
{
    void NotifyOrderReceived(Order order);
}

public interface ITaxCalculator
{
    decimal CalculateTax(Order order);
}

public interface IOrderRepository
{
    void Save(Order order);
}

public interface IReceiptPrinter
{
    void Print(Order order, decimal tax);
}

// Implement segregated services
public class OrderValidator : IOrderValidator
{
    public void Validate(Order order)
    {
        if (order.Items.Count == 0)
            throw new Exception("Order empty");
    }
}

// Injected dependencies
public class OrderProcessor
{
    private readonly IOrderValidator _validator;
    private readonly INotificationService _notificationService;
    private readonly ITaxCalculator _taxCalculator;
    private readonly IOrderRepository _orderRepository;
    private readonly IReceiptPrinter _receiptPrinter;

    public OrderProcessor(
        IOrderValidator validator,
        INotificationService notificationService,
        ITaxCalculator taxCalculator,
        IOrderRepository orderRepository,
        IReceiptPrinter receiptPrinter)
    {
        _validator = validator;
        _notificationService = notificationService;
        _taxCalculator = taxCalculator;
        _orderRepository = orderRepository;
        _receiptPrinter = receiptPrinter;
    }

    public void ProcessOrder(Order order)
    {
        _validator.Validate(order);
        _notificationService.NotifyOrderReceived(order);
        decimal tax = _taxCalculator.CalculateTax(order);
        _orderRepository.Save(order);
        _receiptPrinter.Print(order, tax);
    }
}
```

**Improvements**:
- **SRP**: Each class has one responsibility
- **OCP**: New services can be added without modification
- **DIP**: Depends on abstractions, easy to test and swap implementations

---

### Relationships Between Design Patterns and SOLID

| Pattern | SOLID Principles Realized |
|---------|---------------------------|
| Strategy | OCP (open for extension), DIP (depend on abstraction) |
| Observer | OCP, DIP (loose coupling) |
| Factory | OCP (hide creation), DIP (abstract creation) |
| State | SRP (each state encapsulated), OCP (new states) |
| Decorator | OCP (extend without modification), SRP (single concern) |
| Singleton | DIP (single access point) |
| Command | SRP (request encapsulation), OCP (new commands) |
| Template Method | OCP (extend algorithm), DIP (depend on abstract template) |

---

### Practice Exercise: Refactoring Example

**Original Code (Multiple SOLID Violations)**:
```csharp
public class PaymentProcessor
{
    public void ProcessPayment(string cardNumber, decimal amount, string cardType)
    {
        if (cardType == "Visa")
        {
            // Visa payment logic
            Console.WriteLine($"Processing Visa payment: ${amount}");
        }
        else if (cardType == "MasterCard")
        {
            // MasterCard payment logic
            Console.WriteLine($"Processing MasterCard payment: ${amount}");
        }
        else if (cardType == "AmEx")
        {
            // AmEx payment logic
            Console.WriteLine($"Processing AmEx payment: ${amount}");
        }

        // Log payment
        Console.WriteLine($"Payment logged for card {cardNumber}");

        // Send confirmation
        Console.WriteLine($"Confirmation sent for ${amount}");
    }
}
```

**Issues**:
- Violates OCP: Adding new card types requires modification
- Violates SRP: Multiple responsibilities (payment processing, logging, notification)
- Violates DIP: Direct dependencies on implementation

**Refactored Code**:
```csharp
// Strategy Pattern + SOLID
public interface IPaymentStrategy
{
    void Process(decimal amount);
}

public class VisaPayment : IPaymentStrategy
{
    public void Process(decimal amount)
    {
        Console.WriteLine($"Processing Visa payment: ${amount}");
    }
}

public class MasterCardPayment : IPaymentStrategy
{
    public void Process(decimal amount)
    {
        Console.WriteLine($"Processing MasterCard payment: ${amount}");
    }
}

public class AmexPayment : IPaymentStrategy
{
    public void Process(decimal amount)
    {
        Console.WriteLine($"Processing AmEx payment: ${amount}");
    }
}

// Segregate responsibilities
public interface IPaymentLogger
{
    void LogPayment(string cardNumber, decimal amount);
}

public interface IConfirmationService
{
    void SendConfirmation(decimal amount);
}

public class PaymentLogger : IPaymentLogger
{
    public void LogPayment(string cardNumber, decimal amount)
    {
        Console.WriteLine($"Payment logged for card {cardNumber}");
    }
}

public class ConfirmationService : IConfirmationService
{
    public void SendConfirmation(decimal amount)
    {
        Console.WriteLine($"Confirmation sent for ${amount}");
    }
}

// Orchestrator with injected dependencies (DIP)
public class PaymentProcessor
{
    private readonly IPaymentLogger _logger;
    private readonly IConfirmationService _confirmationService;

    public PaymentProcessor(IPaymentLogger logger, IConfirmationService confirmationService)
    {
        _logger = logger;
        _confirmationService = confirmationService;
    }

    public void ProcessPayment(IPaymentStrategy paymentStrategy, string cardNumber, decimal amount)
    {
        paymentStrategy.Process(amount);          // SRP: payment processing
        _logger.LogPayment(cardNumber, amount);    // SRP: logging
        _confirmationService.SendConfirmation(amount);  // SRP: notification
    }
}

// Usage
var logger = new PaymentLogger();
var confirmationService = new ConfirmationService();
var processor = new PaymentProcessor(logger, confirmationService);

processor.ProcessPayment(new VisaPayment(), "1234-5678", 100);
processor.ProcessPayment(new MasterCardPayment(), "8765-4321", 50);

// Adding new card type - NO modification needed!
processor.ProcessPayment(new AmexPayment(), "9999-9999", 75);
```

**SOLID Principles Implemented**:
- ✅ **SRP**: Each class has one responsibility
- ✅ **OCP**: New payment types can be added without modifying existing code
- ✅ **LSP**: All payment strategies are interchangeable
- ✅ **ISP**: Interfaces are focused and specific
- ✅ **DIP**: Depends on abstractions (interfaces), not concrete classes
- **Bonus**: Uses Strategy Design Pattern

---

## Summary

This study guide covers the complete curriculum for all four modules with detailed explanations, UML diagrams, C# code examples, and practical scenarios. Key topics include:

- **DevOps**: Principles, culture, Azure DevOps platform, and CI/CD pipelines
- **Git**: Version control concepts, internal workings, team workflows, and command-line usage
- **Design Patterns**: 8 essential patterns with UML diagrams, implementations, and selection guidelines
- **SOLID**: 5 principles with violation/correction examples and integration with design patterns

Focus on understanding the "why" behind each concept, not just memorizing facts. Practice recognizing patterns in existing code and applying SOLID principles to refactor problematic designs.
