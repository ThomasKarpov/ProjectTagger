# Github workflow

## Get and merge updates into your local branch
- Fetch updates using `git pull`.
- Make sure you are in your branch, if not, use `git checkout YourBranchName`.
- Merge master content into your branch using `git merge origin/master`.
- when prompted, complete merge by typing :wq (write & quit) then enter.

## Send updates from your branch to master
- Add files for committing using `git add .` (adds all changed files in current folder location and all its children).
- Commit changes using `git commit "This commit message describes the commit"`.
- push local changes to server using `git push`.

Now go to Github and create a [New pull request](https://github.com/Luffiez/ProjectAlpha/pulls) and choose master as bae and your branch as compare. This displays all the changes, click create. After this, other member can see you pull request and you or others can confirm the merge. After this, the changes will be transfered to the master branch.