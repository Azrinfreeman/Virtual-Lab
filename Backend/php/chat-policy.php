<?php
declare(strict_types=1);

function chat_topic(string $context): ?string
{
    $topics = [
        'defaultPrompt' => 'nutrisi dan sistem pencernaan manusia',
        'MainMenuObjektif' => 'objektif pembelajaran BioNutri-MM: teori, makmal maya dan penilaian kendiri',
        'Aktiviti' => 'lapan aktiviti BioNutri-MM: pencernaan, karbohidrat, protein, lipid, tenaga makanan, vitamin C, kesan suhu dan pemakanan sihat',
        'Semakan Markah' => 'cara menyemak markah kuiz dan eksperimen',
        '1.1' => 'organ dan pencernaan manusia', '1.2' => 'penyerapan nutrien',
        '1.3' => 'asimilasi nutrien', '1.4' => 'penyahtinjaan',
    ];
    $activities = [2 => 'karbohidrat dan amilase', 3 => 'protein dan pepsin',
        4 => 'lipid dan lipase', 5 => 'nilai tenaga makanan', 6 => 'vitamin C dan DCPIP',
        7 => 'kesan suhu terhadap vitamin C', 8 => 'Piramid Makanan Malaysia dan Pinggan Sihat Malaysia'];
    foreach ($activities as $activity => $topic) {
        for ($page = 0; $page <= 4; $page++) $topics["$activity.$page"] = $topic;
    }
    return $topics[$context] ?? null;
}

function chat_validate(array $body): bool
{
    return !array_diff(array_keys($body), ['contextId', 'message', 'conversationId', 'requestId'])
        && is_string($body['contextId'] ?? null) && chat_topic($body['contextId']) !== null
        && is_string($body['message'] ?? null) && trim($body['message']) !== ''
        && mb_strlen($body['message']) <= 2000
        && is_string($body['requestId'] ?? null)
        && preg_match('/^[a-f0-9]{8}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{12}$/iD', $body['requestId']) === 1
        && (($body['conversationId'] ?? null) === null || is_string($body['conversationId']));
}

function chat_spend(PDO $db, string $bucket, int $limit, string $expires): void
{
    $insert = $db->prepare('INSERT IGNORE INTO chatbot_usage (bucket, attempts, expires_at) VALUES (?,0,?)');
    $insert->execute([$bucket, $expires]);
    $update = $db->prepare('UPDATE chatbot_usage SET attempts=attempts+1 WHERE bucket=? AND attempts < ?');
    $update->execute([$bucket, $limit]);
    if ($update->rowCount() !== 1) throw new RuntimeException('quota', 429);
}
