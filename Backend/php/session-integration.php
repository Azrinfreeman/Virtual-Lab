<?php
declare(strict_types=1);

// Include in your existing server login AFTER password verification succeeds.
// Never expose this function through a public unauthenticated token-issuing route.
function issue_chat_session(PDO $db, string $verifiedUserId): array
{
    if ($verifiedUserId === '' || strlen($verifiedUserId) > 128) throw new InvalidArgumentException('Invalid user');
    $token = bin2hex(random_bytes(32));
    $expires = time() + 3600;
    $query = $db->prepare('INSERT INTO chatbot_sessions (token_hash,user_id,expires_at) VALUES (?,?,?)');
    $query->execute([hash('sha256', $token), $verifiedUserId, gmdate('Y-m-d H:i:s', $expires)]);
    return ['chatSessionToken' => $token, 'chatSessionExpiresAt' => $expires];
}

function revoke_chat_session(PDO $db, string $token): void
{
    $query = $db->prepare('DELETE FROM chatbot_sessions WHERE token_hash=?');
    $query->execute([hash('sha256', $token)]);
}
