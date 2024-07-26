# TODO List API

Ini adalah API untuk aplikasi To-Do List yang dibangun menggunakan .NET. Proyek ini mencakup fitur untuk membuat, membaca, memperbarui, dan menghapus tugas.

## Prerequisites

Pastikan Anda memiliki alat dan perangkat lunak berikut diinstal pada sistem Anda:

- [.NET SDK 7.0 atau lebih baru](https://dotnet.microsoft.com/download)
- [Git](https://git-scm.com/downloads)

## Cloning Repository

Untuk memulai, pertama-tama clone repository dari GitHub:

```bash
git clone https://github.com/ZudaPradana/server-to-do-net.git
```

## Menjalankan Server
Untuk menjalankan server, gunakan perintah berikut:
```bash
dotnet run
```

## Schema DB
Untuk menyesuaikan dengan project, anda bisa mengikut query berikut:
```bash
CREATE TABLE todos
(
    Id SERIAL PRIMARY KEY,
    Title VARCHAR(255),
    Description TEXT,
    DueDate TIMESTAMP,
    IsCompleted BOOLEAN,
    Reminder TIMESTAMP
);
```
