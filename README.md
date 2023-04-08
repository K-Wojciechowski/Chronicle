# Chronicle: A simple, configurable, task-oriented backup system.

A backup system that for backing up specific things (e.g. databases) as opposed to the entire filesystem.
Highly configurable, allowing for backup pipelines to be tailored to the specific system at hand.
Linux and Windows-friendly, async-ready, written in .NET 7.

## Roadmap

### Infrastructure/general

- [x] Basic data model
- [ ] Configuration (probably using YAML)
- [ ] Execution engine
- [ ] Output sinks
- [ ] Executor application to run a single task (for tasks that require superuser privileges)
- [ ] Custom plugins support
- [ ] Cron-friendly mode

### Backup plugins

- [ ] Files and folders
- [ ] Arbitrary commands (saving output or files)
- [ ] SQLite
- [ ] PostgreSQL
- [ ] MySQL/MariaDB
- [ ] git repositories

### Sink plugins

- [ ] Folder
- [ ] Tar (with compression)
- [ ] S3 bucket

### Non-goals

* Incremental backups
* Creating backups on a remote machine
