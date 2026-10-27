<?php
// Copy OUTSIDE public_html as bionutri-chat-config.php; fill via hosting secrets.
return [
    'db_dsn' => getenv('CHAT_DB_DSN') ?: 'mysql:host=localhost;dbname=vlab;charset=utf8mb4',
    'db_user' => getenv('CHAT_DB_USER') ?: '',
    'db_password' => getenv('CHAT_DB_PASSWORD') ?: '',
    'openai_key' => getenv('OPENAI_API_KEY') ?: '',
    'model' => 'gpt-4o-mini',
    'allowed_origin' => 'https://YOUR-GAME-HOST.example',
    'daily_user_limit' => 50,
    'daily_global_limit' => 500,
];
