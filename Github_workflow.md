# Github workflow
`!Note!: You can clone and download from the project without being a member, but you need to be one to push and create pull requests. Contact Erk if you're not a member yet`

## Using Github Desktop
[Installation](https://desktop.github.com/)

### 1. Set up project on your PC
- Download and install Github Desktop
- Open it and press File>Clone Repository
- Select URL
    - Paste repository path as the URL
        - `https://github.com/Luffiez/ProjectAlpha.git`
    - Choose Local path (where the repository will be stored) 
        - Example path `C:\Users\Erk\Documents\Github`
    - Click Clone

Congratulations, you have now sucessully cloned the repository from the the server to you local PC.
    
### 2. Get and merge updates into your local branch

### 3. Send updates from your branch to master
- View your changes in the changes tab on the left hand side. You can see which files have been changed and also preview the changes on the right hand side.
- Press commit and add a descriptive text about what has changed in this commit.
- Push changes to server with push button on top bar.

## Using Gitbash
[Installation](https://gitforwindows.org/)
### 1. Set up project on your PC
- Download and install GitBash (if you don't have it already)
- Open it up and navigate to the location you want the repository to be
> Example path `C:\Users\Erk\Documents\Github`.
- type the following to clone the repository from the server to your machine
> `git clone https://github.com/Luffiez/ProjectAlpha.git`

Congratulations, you have now sucessully cloned the repository from the the server to you local PC.

### 2. Get and merge updates into your local branch
- Fetch updates using `git pull`.
- Make sure you are in your branch, if not, use `git checkout YourBranchName`.
- Merge master content into your branch using `git merge origin/master`.
- when prompted, complete merge by typing :wq (write & quit) then enter.

### 3. Send updates from your branch to master
- Add files for committing using `git add .` (adds all changed files in current folder location and all its children).
- Commit changes using `git commit "This commit message describes the commit"`.
- push local changes to server using `git push`.

Now go to Github and create a [New pull request](https://github.com/Luffiez/ProjectAlpha/pulls) and choose master as bae and your branch as compare. This displays all the changes, click create. After this, other member can see you pull request and you or others can confirm the merge. After this, the changes will be transfered to the master branch.