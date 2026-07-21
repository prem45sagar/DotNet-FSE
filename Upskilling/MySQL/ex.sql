-- Q1 User Upcoming Events
SELECT e.*
FROM Events e
JOIN Registrations r ON e.event_id=r.event_id
JOIN Users u ON r.user_id=u.user_id
WHERE e.status='upcoming'
AND e.city=u.city
ORDER BY e.start_date;

-- Q2 Top Rated Events
SELECT e.title,
AVG(f.rating) avg_rating
FROM Events e
JOIN Feedback f ON e.event_id=f.event_id
GROUP BY e.event_id,e.title
HAVING COUNT(*)>=10
ORDER BY avg_rating DESC;

-- Q3 Inactive Users
SELECT *
FROM Users
WHERE user_id NOT IN
(
SELECT user_id
FROM Registrations
WHERE registration_date >= CURDATE()-INTERVAL 90 DAY
);

-- Q4 Peak Session Hours
SELECT event_id,
COUNT(*) total_sessions
FROM Sessions
WHERE TIME(start_time)
BETWEEN '10:00:00' AND '12:00:00'
GROUP BY event_id;

-- Q5 Most Active Cities
SELECT u.city,
COUNT(DISTINCT r.user_id) registrations
FROM Users u
JOIN Registrations r
ON u.user_id=r.user_id
GROUP BY u.city
ORDER BY registrations DESC
LIMIT 5;

-- Q6 Event Resource Summary
SELECT e.title,
COUNT(r.resource_id) total_resources
FROM Events e
LEFT JOIN Resources r
ON e.event_id=r.event_id
GROUP BY e.event_id,e.title;

-- Q7 Low Feedback Alerts
SELECT u.full_name,
e.title,
f.rating,
f.comments
FROM Feedback f
JOIN Users u ON f.user_id=u.user_id
JOIN Events e ON f.event_id=e.event_id
WHERE f.rating < 3;

-- Q8 Sessions per Upcoming Event
SELECT e.title,
COUNT(s.session_id) session_count
FROM Events e
LEFT JOIN Sessions s
ON e.event_id=s.event_id
WHERE e.status='upcoming'
GROUP BY e.event_id,e.title;

-- Q9 Organizer Event Summary
SELECT u.full_name,
e.status,
COUNT(e.event_id) total_events
FROM Users u
JOIN Events e
ON u.user_id=e.organizer_id
GROUP BY u.full_name,e.status;

-- Q10 Feedback Gap
SELECT DISTINCT e.title
FROM Events e
JOIN Registrations r
ON e.event_id=r.event_id
LEFT JOIN Feedback f
ON e.event_id=f.event_id
WHERE f.feedback_id IS NULL;

-- Q11 Daily New User Count
SELECT registration_date,
COUNT(*) total_users
FROM Users
WHERE registration_date >= CURDATE()-INTERVAL 7 DAY
GROUP BY registration_date;

-- Q12 Event with Maximum Sessions
SELECT e.title,
COUNT(s.session_id) total_sessions
FROM Events e
JOIN Sessions s
ON e.event_id=s.event_id
GROUP BY e.event_id,e.title
HAVING COUNT(s.session_id)=
(
SELECT MAX(cnt)
FROM
(
SELECT COUNT(*) cnt
FROM Sessions
GROUP BY event_id
) x
);

-- Q13 Average Rating per City
SELECT e.city,
AVG(f.rating) avg_rating
FROM Events e
JOIN Feedback f
ON e.event_id=f.event_id
GROUP BY e.city;

-- Q14 Most Registered Events
SELECT e.title,
COUNT(r.registration_id) total_registrations
FROM Events e
JOIN Registrations r
ON e.event_id=r.event_id
GROUP BY e.event_id,e.title
ORDER BY total_registrations DESC
LIMIT 3;

-- Q15 Event Session Time Conflict
SELECT s1.event_id,
s1.title,
s2.title
FROM Sessions s1
JOIN Sessions s2
ON s1.event_id=s2.event_id
AND s1.session_id<s2.session_id
AND s1.start_time<s2.end_time
AND s1.end_time>s2.start_time;

-- Q16 Unregistered Active Users
SELECT *
FROM Users
WHERE registration_date >= CURDATE()-INTERVAL 30 DAY
AND user_id NOT IN
(
SELECT user_id
FROM Registrations
);

-- Q17 Multi Session Speakers
SELECT speaker_name,
COUNT(*) total_sessions
FROM Sessions
GROUP BY speaker_name
HAVING COUNT(*)>1;

-- Q18 Resource Availability Check
SELECT e.title
FROM Events e
LEFT JOIN Resources r
ON e.event_id=r.event_id
WHERE r.resource_id IS NULL;

-- Q19 Completed Events with Feedback Summary
SELECT e.title,
COUNT(DISTINCT r.registration_id) registrations,
AVG(f.rating) avg_rating
FROM Events e
LEFT JOIN Registrations r
ON e.event_id=r.event_id
LEFT JOIN Feedback f
ON e.event_id=f.event_id
WHERE e.status='completed'
GROUP BY e.event_id,e.title;

-- Q20 User Engagement Index
SELECT u.full_name,
COUNT(DISTINCT r.event_id) events_attended,
COUNT(DISTINCT f.feedback_id) feedbacks_submitted
FROM Users u
LEFT JOIN Registrations r
ON u.user_id=r.user_id
LEFT JOIN Feedback f
ON u.user_id=f.user_id
GROUP BY u.user_id,u.full_name;

-- Q21 Top Feedback Providers
SELECT u.full_name,
COUNT(f.feedback_id) total_feedbacks
FROM Users u
JOIN Feedback f
ON u.user_id=f.user_id
GROUP BY u.user_id,u.full_name
ORDER BY total_feedbacks DESC
LIMIT 5;

-- Q22 Duplicate Registrations Check
SELECT user_id,
event_id,
COUNT(*) duplicate_count
FROM Registrations
GROUP BY user_id,event_id
HAVING COUNT(*)>1;

-- Q23 Registration Trends
SELECT YEAR(registration_date) yr,
MONTH(registration_date) mn,
COUNT(*) registrations
FROM Registrations
WHERE registration_date >= CURDATE()-INTERVAL 12 MONTH
GROUP BY YEAR(registration_date),
MONTH(registration_date);

-- Q24 Average Session Duration per Event
SELECT event_id,
AVG(
TIMESTAMPDIFF
(
MINUTE,
start_time,
end_time
)
) avg_duration
FROM Sessions
GROUP BY event_id;

-- Q25 Events Without Sessions
SELECT e.title
FROM Events e
LEFT JOIN Sessions s
ON e.event_id=s.event_id
WHERE s.session_id IS NULL;