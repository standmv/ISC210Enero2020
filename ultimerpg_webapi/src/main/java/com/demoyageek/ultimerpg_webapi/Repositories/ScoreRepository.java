package com.demoyageek.ultimerpg_webapi.Repositories;

import com.demoyageek.ultimerpg_webapi.Entities.Score;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.rest.core.annotation.RepositoryRestResource;



@RepositoryRestResource(path = "scores", collectionResourceRel = "scores")
public interface ScoreRepository extends JpaRepository<Score, Integer> {
}
