<?php
declare(strict_types=1);
require_once __DIR__ . '/chat-policy.php';
function check(bool $condition, string $name): void {
    if (!$condition) throw new RuntimeException('Failed: ' . $name);
    echo "PASS: $name\n";
}
$valid = ['contextId' => '2.2', 'message' => 'Apakah fungsi amilase?',
    'conversationId' => null, 'requestId' => '3b241101-e2bb-4255-8caf-4136c566a962'];
check(chat_validate($valid), 'valid lesson request');
check(!chat_validate(array_merge($valid, ['contextId' => 'unknown'])), 'unknown context rejected');
check(!chat_validate(array_merge($valid, ['model' => 'client-selected-model'])), 'client model rejected');
check(!chat_validate(array_merge($valid, ['message' => str_repeat('a', 2001)])), 'oversized message rejected');
check(!chat_validate(array_merge($valid, ['message' => '  '])), 'blank message rejected');
check(!chat_validate(array_merge($valid, ['requestId' => 'invalid'])), 'invalid request ID rejected');
check(!chat_validate(array_merge($valid, ['conversationId' => ['invalid']])), 'invalid conversation rejected');
check(chat_topic('Semakan Markah') !== null, 'existing menu context supported');
for ($activity = 2; $activity <= 8; $activity++) {
    for ($page = 0; $page <= 4; $page++) check(chat_topic("$activity.$page") !== null, "context $activity.$page");
}
